using AnimalesWS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace AnimalesWS.Controllers
{
    public class HomeController : ApiController
    {
        public JsonResult<List<Animal>> Get()
        {
            List<Animal> animales = new List<Animal>();
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cadenaConexion"].ConnectionString))
            {
                conexion.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM animales", conexion))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        animales.Add(new Animal
                        {
                            id = reader.GetInt32(0),
                            nombre = reader.GetString(1),
                            pesoValor = reader.GetDouble(2),
                            alturaValor = reader.GetDouble(3),
                            habitat = reader.GetString(4),
                            nombreCientifico = reader.GetString(5),
                            vertebradoValor = reader.GetBoolean(6),
                            oviparoValor = reader.GetBoolean(7),
                            tipoAlimentacionValor = (TipoAlimentacion)reader.GetInt32(8)
                        });
                    }
                }
            }
            return Json(animales);
        }

        public JsonResult<Estado> Post(AnimalRequest animal_)
        {
            if(animal_ == null)
                return Json(new Estado { detalle = "Faltan parámetros", estado = false });
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cadenaConexion"].ConnectionString))
            {
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO animales VALUES(@id,@nombre,@peso,@altura,@habitat,@nombreCientifico,@vertebrado,@oviparo,@tipoAlimentacion)", conexion))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@id", animal_.id);
                        cmd.Parameters.AddWithValue("@nombre", animal_.nombre);
                        cmd.Parameters.AddWithValue("@peso", animal_.peso);
                        cmd.Parameters.AddWithValue("@altura", animal_.altura);
                        cmd.Parameters.AddWithValue("@habitat", animal_.habitat);
                        cmd.Parameters.AddWithValue("@nombreCientifico", animal_.nombreCientifico);
                        cmd.Parameters.AddWithValue("@vertebrado", animal_.vertebrado);
                        cmd.Parameters.AddWithValue("@oviparo", animal_.oviparo);
                        cmd.Parameters.AddWithValue("@tipoAlimentacion", animal_.tipoAlimentacionValor);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return Json(new Estado { detalle = ex.Message, estado = false });
                    }
                }
            }
            return Json(new Estado { detalle = "", estado = true });
        }
    }
}
