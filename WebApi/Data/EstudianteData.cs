using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Data
{
    public class EstudianteData
    {
        public static bool Registrar(Estudiante oEstudiante)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("registrar_estudiante", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@carnet", oEstudiante.carnet);
                cmd.Parameters.AddWithValue("@nombres", oEstudiante.nombres);
                cmd.Parameters.AddWithValue("@apellidos", oEstudiante.apellidos);
                cmd.Parameters.AddWithValue("@carrera", oEstudiante.carrera);
                cmd.Parameters.AddWithValue("@correo", oEstudiante.correo);
                cmd.Parameters.AddWithValue("@telefono", oEstudiante.telefono);
                cmd.Parameters.AddWithValue("@genero", oEstudiante.genero);
                cmd.Parameters.AddWithValue("@fecha_ingreso", oEstudiante.fecha_ingreso);

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

        public static bool Modificar(Estudiante oEstudiante)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("modificar_estudiante", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@carnet", oEstudiante.carnet);
                cmd.Parameters.AddWithValue("@nombres", oEstudiante.nombres);
                cmd.Parameters.AddWithValue("@apellidos", oEstudiante.apellidos);
                cmd.Parameters.AddWithValue("@carrera", oEstudiante.carrera);
                cmd.Parameters.AddWithValue("@correo", oEstudiante.correo);
                cmd.Parameters.AddWithValue("@telefono", oEstudiante.telefono);
                cmd.Parameters.AddWithValue("@genero", oEstudiante.genero);
                cmd.Parameters.AddWithValue("@fecha_ingreso", oEstudiante.fecha_ingreso);

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

        public static List<Estudiante> Listar()
        {
            List<Estudiante> oListaEstudiante = new List<Estudiante>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("listar_estudiante", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        
                        while (dr.Read())
                        {
                            oListaEstudiante.Add(new Estudiante() {
                                carnet = dr["carnet"].ToString(),
                                nombres = dr["nombres"].ToString(),
                                apellidos = dr["apellidos"].ToString(),
                                carrera = dr["carrera"].ToString(),
                                correo = dr["correo"].ToString(),
                                telefono = dr["telefono"].ToString(),
                                genero = dr["genero"].ToString(),
                                fecha_ingreso = Convert.ToDateTime(dr["fecha_ingreso"].ToString())
                            });
                        }

                    }



                    return oListaEstudiante;
                }
                catch (Exception ex)
                {
                    return oListaEstudiante;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("eliminar_estudiante", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@carnet", id);

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