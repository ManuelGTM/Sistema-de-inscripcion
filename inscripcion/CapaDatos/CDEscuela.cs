using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;
using System.Data;

namespace CapaDatos
{
    public class CDEscuela
    {

        int IdEscuela;
        string Nombre;
        int DistritoEducativo;
        int Regional;
        int CodigoMinerd;
        string Director;
        string Estado;

        public CDEscuela()
        {

        }

        
        public CDEscuela(int IdEscuela, string Nombre, int DistritoEducativo, int Regional, int CodigoMinerd, string Director, string Estado)
        {

            this.IdEscuela = IdEscuela;
            this.Nombre = Nombre;
            this.DistritoEducativo = DistritoEducativo;
            this.Regional = Regional;
            this.CodigoMinerd = CodigoMinerd;
            this.Director = Director;
            this.Estado = Estado;   
        }
        

        public int _IdEscuela { get => IdEscuela; set => IdEscuela = value; }
        public string _Nombre { get => Nombre; set => Nombre = value; }
        public int _DistritoEducativo { get => DistritoEducativo; set => DistritoEducativo = value; }
        public int _Regional { get => Regional; set => Regional = value; }
        public int _CodigoMinerd { get =>CodigoMinerd; set => CodigoMinerd = value; }
        public string _Director { get => Director; set => Director = value; }
        public string _Estado { get => Estado; set => Estado = value; }
        

          public string InsertarEscuela(CDEscuela objEscuela)
            {

                string mensaje = "";
                SqlConnection sqlCon = new SqlConnection();

                try
                {

                    sqlCon.ConnectionString = Sistema_Conexion.miconexion;
                    SqlCommand micomando = new SqlCommand("EscuelaInsertar", sqlCon);
                    sqlCon.Open();
                    micomando.CommandType = CommandType.StoredProcedure;

                    micomando.Parameters.AddWithValue("@pIdEscuela", objEscuela._IdEscuela);
                    micomando.Parameters.AddWithValue("@pNombre", objEscuela._Nombre);
                    micomando.Parameters.AddWithValue("@pDistritoEducativo", objEscuela._DistritoEducativo);
                    micomando.Parameters.AddWithValue("@pRegional", objEscuela._Regional);
                    micomando.Parameters.AddWithValue("@pCodigoMinerd", objEscuela._CodigoMinerd);
                    micomando.Parameters.AddWithValue("@pDirector", objEscuela._Director);
                    micomando.Parameters.AddWithValue("@pEstado", objEscuela._Estado);

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




            public string ActualizarEscuela(CDEscuela objEscuela)
            {

                string mensaje = "";
                SqlConnection sqlCon = new SqlConnection(); 

               try
                {
                    
                    sqlCon.ConnectionString = Sistema_Conexion.miconexion;
                    SqlCommand micomando = new SqlCommand("EscuelaActualizar", sqlCon);
                    sqlCon.Open();

                   micomando.Parameters.AddWithValue("@pIdEscuela", objEscuela._IdEscuela);
                    micomando.Parameters.AddWithValue("@pNombre", objEscuela._Nombre);
                    micomando.Parameters.AddWithValue("@pDistritoEducativo", objEscuela._DistritoEducativo);
                    micomando.Parameters.AddWithValue("@pRegional", objEscuela._Regional);
                    micomando.Parameters.AddWithValue("@pCodigoMinerd", objEscuela._CodigoMinerd);
                    micomando.Parameters.AddWithValue("@pDirector", objEscuela._Director);
                    micomando.Parameters.AddWithValue("@pEstado", objEscuela._Estado);

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


            public DataTable DataTableEscuela(string miparametro)
            {
                DataTable dt = new DataTable(); // Creacion de la tabla que muestra el cargo
                SqlDataReader leerDatos; //Creacion del data Reader

                try
                {
                    SqlCommand sqlCmd = new SqlCommand(); //Establece un comando
                    sqlCmd.Connection = new Sistema_Conexion().dbconexion;//Conexion que usara el comando
                    sqlCmd.Connection.Open();// Abrir la base de datos
                    sqlCmd.CommandText = "EscuelaConsultar"; //Nombre de proc. Almacenado
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
