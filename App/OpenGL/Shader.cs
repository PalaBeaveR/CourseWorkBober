using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using PlantUmlClassDiagramGenerator.Attributes;

namespace App.OpenGL
{
    [PlantUmlDiagram]
    [SuppressMessage("ReSharper", "PrivateFieldCanBeConvertedToLocalVariable")]
    public sealed class Shader: IDisposable
    {
        private readonly int _handle;
        private readonly int _vertexShader;
        private readonly int _fragmentShader;

        public Shader(string vertex_path, string fragment_path): this(File.ReadAllBytes(vertex_path), File.ReadAllBytes(fragment_path))
        {
        }
        public Shader(byte[] vertex_data, byte[] fragment_data)
        {
            int    vertexShader;
            string vertexShaderSource = Encoding.ASCII.GetString(vertex_data);

            string fragmentShaderSource = Encoding.ASCII.GetString(fragment_data);

            this._vertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(this._vertexShader, vertexShaderSource);

            this._fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(this._fragmentShader, fragmentShaderSource);

            GL.CompileShader(this._vertexShader);

            GL.GetShader(this._vertexShader, ShaderParameter.CompileStatus, out int success);
            if (success == 0)
            {
                string infoLog = GL.GetShaderInfoLog(this._vertexShader);
                Console.WriteLine(infoLog);
            }

            GL.CompileShader(this._fragmentShader);

            GL.GetShader(this._fragmentShader, ShaderParameter.CompileStatus, out success);
            if (success == 0)
            {
                string infoLog = GL.GetShaderInfoLog(this._fragmentShader);
                Console.WriteLine(infoLog);
            }

            this._handle = GL.CreateProgram();

            GL.AttachShader(this._handle, this._vertexShader);
            GL.AttachShader(this._handle, this._fragmentShader);

            GL.LinkProgram(this._handle);

            GL.GetProgram(this._handle, GetProgramParameterName.LinkStatus, out success);
            if (success == 0)
            {
                string infoLog = GL.GetProgramInfoLog(this._handle);
                Console.WriteLine(infoLog);
            }

            GL.DetachShader(this._handle, this._vertexShader);
            GL.DetachShader(this._handle, this._fragmentShader);
            GL.DeleteShader(this._fragmentShader);
            GL.DeleteShader(this._vertexShader);
        }

        public void Use()
        {
            GL.UseProgram(this._handle);
        }

        private bool _disposedValue = false;

        private void Dispose(bool disposing) {
            if (this._disposedValue) return;
            
            GL.DeleteProgram(this._handle);

            this._disposedValue = true;
        }

        ~Shader()
        {
            if (this._disposedValue == false)
            {
                Console.WriteLine(@"GPU Resource leak! Did you forget to call Dispose()?");
            }
        }


        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int GetAttribLocation(string attrib) {
            return GL.GetAttribLocation(this._handle, attrib);
        }
    }
}
