using GAP.Domain;
using System;
using System.Data;

namespace GAP.Model
{
    public class UsuarioModel : BaseModel
    {
        public UsuarioModel() : base()
        { }

        public void Insertar(Usuario usuario)
        {
            try
            {
                cmd.CommandText = "UsuariosInsertar";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Ema", usuario.Email);
                cmd.Parameters["@Ema"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@Nom", usuario.Nombre);
                cmd.Parameters["@Nom"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@Ape", usuario.Apellido);
                cmd.Parameters["@Ape"].Direction = ParameterDirection.Input;

                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public void InsertarSeguridad(Usuario usuario)
        {
            try
            {
                cmd.CommandText = "UsuariosSeguridadInsertar";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Ema", usuario.Email);
                cmd.Parameters["@Ema"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@pass", usuario.ClaveSafe);
                cmd.Parameters["@pass"].Direction = ParameterDirection.Input;

                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}