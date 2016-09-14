using GAP.Domain;
using GAP.Model;

namespace GAP.BussinesLogic
{
    public class UsuarioLogic
    {
        UsuarioModel usuarioModel;

        public void Insertar(Usuario usuario)
        {
            usuarioModel = new UsuarioModel();
            usuarioModel.Insertar(usuario);
        }

        public void InsertarSeguridad(Usuario usuario)
        {
            usuarioModel = new UsuarioModel();
            usuarioModel.InsertarSeguridad(usuario);
        }

        public bool ValidarUsuario(Usuario usuario)
        {
            usuarioModel = new UsuarioModel();
            return usuarioModel.ValidarUsuario(usuario);
        }
    }
}