using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;
using System.Data;


namespace CapaDatos
{
    public class CDCurso
    {
        private int IdCurso;
        private string Grado;
        private string Seccion;
        private int IdTutor;
        private string Estado;

        public CDCurso()
        {

        }

        public CDCurso(int IdCurso, string Grado, string Seccion, int idTutor, string Estado)
        {
            this.IdCurso = IdCurso;
            this.Grado = Grado;
            this.Seccion = Seccion;
            this.IdTutor = idTutor;
            this.Estado = Estado;
        }


        public int _IdCurso
        {
            get { return IdCurso; }
            set { IdCurso = value; }
        }

        public string _Grado {
            get { return Grado; }
            set { Grado = value; }
        }

        public string _Seccion {
            get { return Seccion; }
            set { Seccion = value; }
        }

        public int _IdTutor {
            get { return IdTutor; }
            set { IdTutor = value; }
        }

        public string _Estado {
            get { return Estado; }
            set { Estado = value; }
        }

              
        public string InsertarCurso(CDCurso objCurso)
        {

            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {

                sqlCon.ConnectionString = Sistema_Conexion.miconexion;
                SqlCommand micomando = new SqlCommand("CursoInsertar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@pIdCurso", objCurso.IdCurso);
                micomando.Parameters.AddWithValue("@pGrado", objCurso.Grado);
                micomando.Parameters.AddWithValue("@pSeccion", objCurso.Seccion);
                micomando.Parameters.AddWithValue("@pIdTutor", objCurso.IdTutor);
                micomando.Parameters.AddWithValue("@pEstado", objCurso.Estado);

                mensaje = micomando.ExecuteNonQuery() == 1 ? "Insercion de datos completada correctamente"
                                                             : "No se pudo insertar correctamente los nuevos datos";

            }
            catch (Exception e)
            {
                mensaje = e.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }

            return "";
        }            

         public string ActualizarCurso(CDCurso objCurso)
                {

                    string mensaje = "";
                    SqlConnection sqlCon = new SqlConnection(); 

                   try
                    {
                        
                        sqlCon.ConnectionString = Sistema_Conexion.miconexion;
                        SqlCommand micomando = new SqlCommand("CursoActualizar", sqlCon);
                        sqlCon.Open();
                        micomando.CommandType = CommandType.StoredProcedure;
                        micomando.Parameters.AddWithValue("@pIdCurso", objCurso.IdCurso);
                        micomando.Parameters.AddWithValue("@pGrado", objCurso.Grado);
                        micomando.Parameters.AddWithValue("@pSeccion", objCurso.Seccion);
                        micomando.Parameters.AddWithValue("@pIdTutor", objCurso.IdTutor);
                        micomando.Parameters.AddWithValue("@pEstado", objCurso.Estado);

                        mensaje = micomando.ExecuteNonQuery() == 1?"Datos actualizados correctamente"
                                                                     :"No se pudo actualizar correctamente los nuevos datos";

                    }
                    catch (Exception e)
                    {
                        mensaje = e.Message;
                    }
                    finally 
                    {
                        if (sqlCon.State == ConnectionState.Open)
                        {
                            sqlCon.Close();
                        }
                    }
                    
                    
                    return $"{mensaje}";
                }


         public string DataTableCurso(string miparametro)
            {
                DataTable dt = new DataTable(); // Creacion de la tabla que muestra el cargo
                SqlDataReader leerDatos; //Creacion del data Reader

                try
                {
                    SqlCommand sqlCmd = new SqlCommand(); //Establece un comando
                    sqlCmd.Connection = new Sistema_Conexion().dbconexion;//Conexion que usara el comando
                    sqlCmd.Connection.Open();// Abrir la base de datos
                    sqlCmd.CommandText = "CursoConsultar"; //Nombre de proc. Almacenado
                    sqlCmd.CommandType = CommandType.StoredProcedure; // Se trata de un Proc. Almacenado
                    sqlCmd.Parameters.AddWithValue("@pvalor", miparametro); // Se pasa el valor a buscar 
                    leerDatos = sqlCmd.ExecuteReader(); // Lenamos el data reader con los datos resultantes
                    dt.Load(leerDatos); // Se cargan los registros devueltos al DataTable
                    sqlCmd.Connection.Close(); // Se cierra la conexion
                }
                catch (Exception e)
                {
                    dt = null; //si ocurre un erro se anula el DataTable
                }
               

                return $"{dt}";
        }









    }
}
