using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GAP.Model;
using GAP.Domain;
using GAP.Utility;

namespace GAP.UnitTest
{
    [TestClass]
    public class UsuarioTest
    {
        [TestMethod]
        public void InsertarUSuarioOK()
        {
            Usuario usuario = new Usuario();
            usuario.Apellido = "Marin";
            usuario.Email = "kelu";
            usuario.Nombre = "Kelly";
            UsuarioModel usuarioModel = new UsuarioModel();
            usuarioModel.Insertar(usuario);
        }

        [TestMethod]
        public void InsertarSeguridadOk()
        {
            Usuario usuario = new Usuario();
            usuario.Apellido = "Marin";
            usuario.Email = "kelu";
            usuario.Nombre = "Kelly";
            usuario.Clave = "Kelly";
            usuario.ClaveSafe = Seguridad.Encrypt("Kelly");
            UsuarioModel usuarioModel = new UsuarioModel();
            usuarioModel.InsertarSeguridad(usuario);
        }
    }
}
