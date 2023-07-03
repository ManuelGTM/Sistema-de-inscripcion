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
     public class CDPeriodo
     {
        private int IdPeriodo;
        private string PeriodoEscolar;
        private string Slogan;
        private string Desde;
        private string Hasta; 
        private string Estado;


        public CDPeriodo(int IdPeriodo, string PeriodoEscolar, string Slogan, string Desde, string Hasta, string Estado)
        {
            this.IdPeriodo = IdPeriodo;
            this.PeriodoEscolar = PeriodoEscolar;
            this.Slogan = Slogan;
            this.Desde = Desde;
            this.Hasta = Hasta;
            this.Estado = Estado;
        }


        public int _IdPeriodo {get => IdPeriodo; set => IdPeriodo = value;}
        public string _PeriodoEscolar { get => PeriodoEscolar; set => PeriodoEscolar = value;}
        public string _Slogan { get => Slogan; set => Slogan = value; }    
        public string _Desde { get => Desde; set => Desde = value;}
        public string _Hasta { get => Hasta; set => Hasta = value;}
        public string _Estado {get => Estado; set => Estado = value; } 




        public string InsertarPeriodo(CDPeriodo objPeriodo)
        {

            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {

                sqlCon.ConnectionString = Sistema_Conexion.miconexion;
                SqlCommand micomando = new SqlCommand("PeriodoInsertar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@pIdPeriodo", objPeriodo._IdPeriodo);
                micomando.Parameters.AddWithValue("@pPeriodoEscolar", objPeriodo._PeriodoEscolar);
                micomando.Parameters.AddWithValue("@pSlogan", objPeriodo._Slogan);
                micomando.Parameters.AddWithValue("@pDesde", objPeriodo._Desde);
                micomando.Parameters.AddWithValue("@pHasta", objPeriodo._Hasta);
                micomando.Parameters.AddWithValue("@pEstado ", objPeriodo._Estado);

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


                public string ActualizarPeriodo(CDPeriodo objPeriodo)
                {

                    string mensaje = "";
                    SqlConnection sqlCon = new SqlConnection(); 

                   try
                    {
                        
                        sqlCon.ConnectionString = Sistema_Conexion.miconexion;
                        SqlCommand micomando = new SqlCommand("PeriodoActualizar", sqlCon);
                        sqlCon.Open();
                        micomando.Parameters.AddWithValue("@pIdPeriodo", objPeriodo._IdPeriodo);
                        micomando.Parameters.AddWithValue("@pPeriodoEscolar", objPeriodo._PeriodoEscolar);
                        micomando.Parameters.AddWithValue("@pSlogan", objPeriodo._Slogan);
                        micomando.Parameters.AddWithValue("@pDesde", objPeriodo._Desde);
                        micomando.Parameters.AddWithValue("@pHasta", objPeriodo._Hasta);
                        micomando.Parameters.AddWithValue("@pEstado ", objPeriodo._Estado);

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


         public DataTable DataTablePeriodo(string miparametro)
            {
                DataTable dt = new DataTable(); // Creacion de la tabla que muestra el cargo
                SqlDataReader leerDatos; //Creacion del data Reader

                try
                {
                    SqlCommand sqlCmd = new SqlCommand(); //Establece un comando
                    sqlCmd.Connection = new Sistema_Conexion().dbconexion;//Conexion que usara el comando
                    sqlCmd.Connection.Open();// Abrir la base de datos
                    sqlCmd.CommandText = "PeriodoConsultar"; //Nombre de proc. Almacenado
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
               

                return dt;
        }








    }
}
