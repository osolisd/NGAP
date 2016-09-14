using GAP.Domain;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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

        public List<Imagen> ObtenerImagenes()
        {
            List<Imagen> listImagen = new List<Imagen>();

            try
            {
                cmd.CommandText = "ImagenesObtener";
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Imagen imagen = new Imagen();
                        imagen.ImagenId = Convert.ToInt32(rdr["ImagenId"]);
                        imagen.Servidor = Convert.ToString(rdr["Servidor"]);
                        imagen.Nombre = Convert.ToString(rdr["Nombre"]);
                        listImagen.Add(imagen);
                    }
                }

                return listImagen;
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

        public List<Imagen> ObtenerImagenesUsuario(string email)
        {
            List<Imagen> listImagen = new List<Imagen>();

            try
            {
                cmd.CommandText = "ImagenesObtenerUsuario";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ema", email);
                cmd.Parameters["@ema"].Direction = ParameterDirection.Input;

                connection.Open();

                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Imagen imagen = new Imagen();
                        imagen.ImagenId = Convert.ToInt32(rdr["ImagenId"]);
                        imagen.Servidor = Convert.ToString(rdr["Servidor"]);
                        imagen.Nombre = Convert.ToString(rdr["Nombre"]);
                        listImagen.Add(imagen);
                    }
                }

                return listImagen;
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