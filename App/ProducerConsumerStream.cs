using PlantUmlClassDiagramGenerator.Attributes;

namespace App;

public class ProducerConsumerStream : Stream {
  [PlantUmlIgnoreAssociation]
  private readonly MemoryStream _innerStream = new MemoryStream();
  private readonly object       _lockable    = new object();

  private bool _disposed = false;

  private long _readPosition = 0;

  private long _writePosition = 0;

  ~ProducerConsumerStream() {
    this.Dispose(false);
  }

  public override bool CanRead => true;

  public override bool CanSeek => false;

  public override bool CanWrite => true;

  public override long Length {
    get {
      lock (this._lockable) {
        return this._innerStream.Length;
      }
    }
  }

  public override long Position {
    get {
      lock (this._lockable) {
        return this._innerStream.Position;
      }
    }

    set => throw new NotSupportedException();
  }

  [PlantUmlIgnoreAssociation]
  private Speed _speed = new Speed();

  public void SetSpeed(uint n, uint out_of) {
    this._speed.N     = n;
    this._speed.OutOf = out_of;
  }

  public override void Flush() {
    lock (this._lockable) {
      this._innerStream.Flush();
    }
  }

  private uint _counter  = 0;
  private byte _lastRead = 0;

  public override int Read(byte[] buffer, int offset, int count) {
    lock (this._lockable) {
      int readTotal = 0;
      for (int i = 0; i < count; i++) {
        this._counter += this._speed.N;

        uint readSize = this._counter / this._speed.OutOf;

        this._counter -= readSize * this._speed.OutOf;

        if (readSize == 0) {
          buffer[offset + i] = this._lastRead;
        } else {
          this._innerStream.Position = this._readPosition;
          byte[] internalBuffer = new byte[readSize];
          int read = this._innerStream.Read(internalBuffer, 0, (int)readSize);

          if (read == 0) {
            break;
          }

          uint average = 0;

          for (uint n = 0; n < read; n++) {
            average += internalBuffer[n];
          }

          this._lastRead     = (byte)(average / read);
          buffer[offset + i] = this._lastRead;

          this._readPosition = this._innerStream.Position;
        }

        readTotal++;
      }


      return readTotal;
    }
  }

//  public override int Read(byte[] buffer, int offset, int count) {
//    lock (this._lockable) {
//      this._innerStream.Position = this._readPosition;
//      int read = this._innerStream.Read(buffer, offset, count);
//      this._readPosition = this._innerStream.Position;
//
//
//      return read;
//    }
//  }

  public override long Seek(long offset, SeekOrigin origin) {
    // Seek is for read only
    return this._readPosition;
  }

  public override void SetLength(long value) {
    this._innerStream.SetLength(value);
  }

  public void Clear() {
    this.SetLength(0);
    this._readPosition         = 0;
    this._writePosition        = 0;
    this._innerStream.Capacity = 0;
  }

  public override void Write(byte[] buffer, int offset, int count) {
    lock (this._lockable) {
      this._innerStream.Position = this._writePosition;
      this._innerStream.Write(buffer, offset, count);
      this._writePosition = this._innerStream.Position;
    }
  }

  protected override void Dispose(bool disposing) {
    if (this._disposed) {
      return;
    }

    if (disposing) {
      // Free managed objects help by this instance
      if (this._innerStream != null) {
        this._innerStream.Dispose();
      }
    }

    // Free any unmanaged objects here.
    this._disposed = true;

    // Call the base class implementation.
    base.Dispose(disposing);
  }
}

struct Speed {
  public uint N     = 1;
  public uint OutOf = 1;

  public Speed() {
  }
}