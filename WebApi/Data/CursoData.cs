using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Data
{
    public class CursoData
    {
        public static bool Registrar(Curso oCurso)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("registrar_curso", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_curso", oCurso.id_curso);
                cmd.Parameters.AddWithValue("@nombre", oCurso.nombre);
                cmd.Parameters.AddWithValue("@semestre", oCurso.semestre);
                cmd.Parameters.AddWithValue("@valor_creditos", oCurso.valor_creditos);

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

        public static bool Modificar(Curso oCurso)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("modificar_curso", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_curso", oCurso.id_curso);
                cmd.Parameters.AddWithValue("@nombre", oCurso.nombre);
                cmd.Parameters.AddWithValue("@semestre", oCurso.semestre);
                cmd.Parameters.AddWithValue("@valor_creditos", oCurso.valor_creditos);

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

        public static List<Curso> Listar()
        {
            List<Curso> oListaCurso = new List<Curso>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("listar_curso", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        
                        while (dr.Read())
                        {
                            oListaCurso.Add(new Curso() {
                                id_curso = Convert.ToInt32(dr["id_curso"]),
                                nombre = dr["nombre"].ToString(),
                                semestre = dr["semestre"].ToString(),
                                valor_creditos = dr["valor_creditos"].ToString()
                            });
                        }

                    }



                    return oListaCurso;
                }
                catch (Exception ex)
                {
                    return oListaCurso;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("eliminar_curso", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_curso", id);

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