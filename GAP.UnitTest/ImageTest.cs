using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GAP.Domain;
using GAP.Model;

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
    }
}