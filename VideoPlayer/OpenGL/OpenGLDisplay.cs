using OpenTK.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.OpenGL;
using App.Properties;
using OpenTK.Graphics.OpenGL4;
using PlantUmlClassDiagramGenerator.Attributes;
using PixelFormat = OpenTK.Graphics.OpenGL4.PixelFormat;

namespace App.Controls {
  [PlantUmlDiagram]
  public partial class OpenGLDisplay : GLControl {
    private bool _loaded = false;

    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);

      GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
      this._shader = new Shader(
        Resources.vertex.Skip(3).ToArray(),
        Resources.fragment.Skip(3).ToArray()
      );

      this._loaded = true;
      this.Resize();

      this.SetupTexture();
      this._shader.Use();
      this.VboSetup(); // This one needs to be first
      this.VaoSetup();
      this.EboSetup();
    }

    private void SetupTexture() {
      this._textureId = GL.GenTexture();

      GL.BindTexture(TextureTarget.Texture2D, this._textureId);
      GL.TexParameter(
        TextureTarget.Texture2D,
        TextureParameterName.TextureMinFilter,
        (int)TextureMinFilter.Nearest
      );
      GL.TexParameter(
        TextureTarget.Texture2D,
        TextureParameterName.TextureMagFilter,
        (int)TextureMagFilter.Nearest
      );
      GL.TexParameter(
        TextureTarget.Texture2D,
        TextureParameterName.TextureWrapS,
        (int)TextureWrapMode.Repeat
      );
      GL.TexParameter(
        TextureTarget.Texture2D,
        TextureParameterName.TextureWrapT,
        (int)TextureWrapMode.Repeat
      );
    }

    public OpenGLDisplay() {
      this.InitializeComponent();
    }

    private int    _vertexBufferObject;
    private int    _elementBufferObject;
    private int    _vertexArrayObject;
    private Shader _shader;

    private byte[]? _image;

    public byte[]? Image {
      get => this._image;
      set {
        this._image = value;
        if (this._loaded)
          this.Invoke(this.Invalidate);
      }
    }

    [PlantUmlIgnoreAssociation]
    private Size _imageSize = new Size(512, 512);

    [PlantUmlIgnoreAssociation]
    public Size ImageSize {
      get => this._imageSize;
      set {
        this._imageSize = value;
        this.UpdateTextureSize();
      }
    }

    private int _textureId;
    
    protected override void OnResize(EventArgs e) {
      base.OnResize(e);

      if (!this._loaded) return;
      
        
      this.Resize();

      //      if (rectRatio > imageRatio) {
//        // based on the widths
//        float scale = this.Width / (float)this._imageSize.Width;
//        float glPos = scale;
//        
//        this._vertices[1]      = glPos;
//        this._vertices[1 + 5]  = -glPos;
//        this._vertices[1 + 10] = -glPos;
//        this._vertices[1 + 15] = glPos;
//        this._vertices[0]      = 1;
//        this._vertices[0 + 5]  = 1;
//        this._vertices[0 + 10] = -1;
//        this._vertices[0 + 15] = -1;
//      }
//
//      if (rectRatio < imageRatio) {
//        // based on the height
//        float scale = this.Height / (float)this._imageSize.Height;
//        
//        float glPos = scale;
//        
//        this._vertices[1]      = 1;
//        this._vertices[1 + 5]  = -1;
//        this._vertices[1 + 10] = -1;
//        this._vertices[1 + 15] = 1;
//        this._vertices[0]      = glPos;
//        this._vertices[0 + 5]  = glPos;
//        this._vertices[0 + 10] = -glPos;
//        this._vertices[0 + 15] = -glPos;
//      }
//      
//      this.UpdateVbo();
    }

    private void Resize() {
      double imageRatio
        = this._imageSize.Height / (double)this._imageSize.Width;
      double rectRatio = this.Height / (double)this.Width;

      if (rectRatio < imageRatio) {
        float scale          = this.Height           / (float)this._imageSize.Height;
        float imageSizeWidth = this._imageSize.Width * scale;
        GL.Viewport((int)((this.Width - imageSizeWidth) / 2), 0, (int)imageSizeWidth, (int)(this._imageSize.Height * scale));
      } else {
        float scale           = this.Width             / (float)this._imageSize.Width;
        float imageSizeHeight = this._imageSize.Height * scale;
        GL.Viewport(0, (int)((this.Height - imageSizeHeight) / 2), (int)(this._imageSize.Width * scale), (int)imageSizeHeight);
      }
    }

    private readonly float[] _vertices = {
      //Position          Texture coordinates
      1f, 1f, 0.0f, 1.0f, 0.0f,   // top right
      1f, -1f, 0.0f, 1.0f, 1.0f,  // bottom right
      -1f, -1f, 0.0f, 0.0f, 1.0f, // bottom left
      -1f, 1f, 0.0f, 0.0f, 0.0f,  // top left
    };

    private readonly uint[] _indices = {
      // note that we start from 0!
      0, 1, 3, // first triangle
      1, 2, 3,  // second triangle
    };

    private void UpdateTextureSize() {
      if (!this._loaded) return;
      this.Resize();
      GL.TexImage2D(
        TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb,
        this._imageSize.Width, this._imageSize.Height,
        0, PixelFormat.Bgr, PixelType.Float, new IntPtr()
      );
    }

    protected override void OnPaint(PaintEventArgs pe) {
      base.OnPaint(pe);
      GL.Clear(ClearBufferMask.ColorBufferBit);

      if (this._image == null) return;

      GL.TexSubImage2D(
        TextureTarget.Texture2D, 0, 0, 0, this._imageSize.Width,
        this._imageSize.Height, PixelFormat.Bgr,
        PixelType.UnsignedByte, this._image
      );

      GL.DrawElements(
        PrimitiveType.Triangles, this._indices.Length,
        DrawElementsType.UnsignedInt, 0
      );

      this.SwapBuffers();
    }

    private void VaoSetup() {
      this._vertexArrayObject = GL.GenVertexArray();
      GL.BindVertexArray(this._vertexArrayObject);

      int positionLocation = this._shader.GetAttribLocation("position");
      GL.EnableVertexAttribArray(positionLocation);
      GL.VertexAttribPointer(
        0, 3, VertexAttribPointerType.Float, false,
        5 * sizeof(float), 0
      );

      int coordinateLocation = this._shader.GetAttribLocation("coordinate");
      GL.EnableVertexAttribArray(coordinateLocation);
      GL.VertexAttribPointer(
        coordinateLocation, 2,
        VertexAttribPointerType.Float, false,
        5 * sizeof(float),
        3 * sizeof(float)
      );
    }

    private void EboSetup() {
      this._elementBufferObject = GL.GenBuffer();
      GL.BindBuffer(BufferTarget.ElementArrayBuffer, this._elementBufferObject);
      GL.BufferData(
        BufferTarget.ElementArrayBuffer,
        this._indices.Length * sizeof(uint), this._indices,
        BufferUsageHint.StaticDraw
      );
    }
    
    private void VboSetup() {
      this._vertexBufferObject = GL.GenBuffer();
      GL.BindBuffer(BufferTarget.ArrayBuffer, this._vertexBufferObject);
      GL.BufferData(
        BufferTarget.ArrayBuffer,
        this._vertices.Length * sizeof(float), this._vertices,
        BufferUsageHint.DynamicDraw
      );
    }
    
    private void UpdateVbo() {
//      GL.BindBuffer(BufferTarget.ArrayBuffer, this._vertexBufferObject);
      GL.BufferSubData(BufferTarget.ArrayBuffer, 0, this._vertices.Length * sizeof(float), this._vertices);
    }

    
  }
}