using GAP.Domain;
using GAP.Model;
using System.Collections.Generic;

namespace GAP.BussinesLogic
{
    public class ImagenLogic
    {
        ImagenModel imagenModel;

        public void Insertar(Imagen imagen)
        {
            imagenModel = new ImagenModel();
            imagenModel.Insertar(imagen);
        }

        public List<Imagen> ObtenerImagenes()
        {
            imagenModel = new ImagenModel();
            return imagenModel.ObtenerImagenes();
        }

        public List<Imagen> ObtenerImagenesUsuario(string email)
        {
            imagenModel = new ImagenModel();
            return imagenModel.ObtenerImagenesUsuario(email);
        }

    }
}