using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Data
{
    public class AsignacionData
    {
        public static bool Registrar(Asignacion oAsignacion)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("registrar_asignacion", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@carnet", oAsignacion.carnet);
                cmd.Parameters.AddWithValue("@id_curso", oAsignacion.id_curso);
                cmd.Parameters.AddWithValue("@seccion", oAsignacion.seccion);
                cmd.Parameters.AddWithValue("@fecha_realizacion", oAsignacion.fecha_realizacion);
                cmd.Parameters.AddWithValue("@semestre", oAsignacion.semestre);
                cmd.Parameters.AddWithValue("@anho", oAsignacion.anho);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool Modificar(Asignacion oAsignacion)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("modificar_asignacion", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_asignacion", oAsignacion.id_asignacion);
                cmd.Parameters.AddWithValue("@carnet", oAsignacion.carnet);
                cmd.Parameters.AddWithValue("@id_curso", oAsignacion.id_curso);
                cmd.Parameters.AddWithValue("@seccion", oAsignacion.seccion);
                cmd.Parameters.AddWithValue("@fecha_realizacion", oAsignacion.fecha_realizacion);
                cmd.Parameters.AddWithValue("@semestre", oAsignacion.semestre);
                cmd.Parameters.AddWithValue("@anho", oAsignacion.anho);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static List<Asignacion> Listar()
        {
            List<Asignacion> oListaAsignacion = new List<Asignacion>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("listar_asignacion", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        
                        while (dr.Read())
                        {
                            oListaAsignacion.Add(new Asignacion() {
                                id_asignacion = Convert.ToInt32(dr["id_asignacion"]),
                                carnet = dr["carnet"].ToString(),
                                id_curso = Convert.ToInt32(dr["id_curso"]),
                                seccion = dr["seccion"].ToString(),
                                fecha_realizacion = Convert.ToDateTime(dr["fecha_realizacion"].ToString()),
                                semestre = dr["semestre"].ToString(),
                                anho = dr["anho"].ToString()
                            });
                        }

                    }



                    return oListaAsignacion;
                }
                catch (Exception ex)
                {
                    return oListaAsignacion;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("eliminar_asignacion", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_asignacion", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

    }
}