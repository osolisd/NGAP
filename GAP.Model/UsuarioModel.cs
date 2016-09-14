using GAP.Domain;
using MySql.Data.MySqlClient;
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

        public bool ValidarUsuario(Usuario usuario)
        {
            bool usuarioValido = false;

            try
            {
                cmd.CommandText = "UsuariosSeguridadValidar";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ema", usuario.Email);
                cmd.Parameters["@ema"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@pas", usuario.ClaveSafe);
                cmd.Parameters["@pas"].Direction = ParameterDirection.Input;

                connection.Open();

                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        usuarioValido = true;
                    }
                }

                return usuarioValido;
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