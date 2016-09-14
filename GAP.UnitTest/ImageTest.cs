using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GAP.Domain;
using GAP.Model;
using System.Collections.Generic;

namespace GAP.UnitTest
{
    [TestClass]
    public class ImageTest
    {
        [TestMethod]
        public void ImagenInsertarOk()
        {
            Imagen imagen = new Imagen();
            imagen.Email = "kelu";
            imagen.Nombre = "KellyNom";
            imagen.Servidor = "KellySer";
            ImagenModel usuarioModel = new ImagenModel();
            usuarioModel.Insertar(imagen);
        }

        [TestMethod]
        public void ObtenerImagenes()
        {
            ImagenModel usuarioModel = new ImagenModel();
            List<Imagen> listImagen = usuarioModel.ObtenerImagenes();

            Assert.AreNotEqual(0, listImagen.Count);
        }

        [TestMethod]
        public void ObtenerImagenesUsuario()
        {
            ImagenModel usuarioModel = new ImagenModel();
            List<Imagen> listImagen = usuarioModel.ObtenerImagenesUsuario("kelu");

            Assert.AreNotEqual(0, listImagen.Count);
        }
    }
}