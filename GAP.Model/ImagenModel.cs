using GAP.Domain;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace GAP.Model
{
    public class ImagenModel : BaseModel
    {
        public ImagenModel() : base()
        { }

        public void Insertar(Imagen imagen)
        {
            try
            {
                cmd.CommandText = "ImagenesInsertar";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ser", imagen.Servidor);
                cmd.Parameters["@ser"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@nom", imagen.Nombre);
                cmd.Parameters["@nom"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@ema", imagen.Email);
                cmd.Parameters["@ema"].Direction = ParameterDirection.Input;

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