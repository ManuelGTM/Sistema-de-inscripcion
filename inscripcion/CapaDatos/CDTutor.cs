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
    public class CDTutor
    {

        private int IdTutor;
        private string Nombre;
        private string Apellidos;
        private string Telefono;
        private string Cedula;
        private string Direccion;
        private string Estado;

        public CDTutor()
        {
        }

        public CDTutor(int Tutor, string Nombre, string Apellidos, string Telefono, string Cedula, string Direccion,  string Estado) {

            this.IdTutor = Tutor;
            this.Nombre = Nombre;
            this.Apellidos = Apellidos;
            this.Telefono = Telefono;
            this.Cedula = Cedula;
            this.Direccion = Direccion;
            this.Estado = Estado;
        }

        public int _IdTutor { get => IdTutor; set => IdTutor = value; }
        public string _Nombre { get => Nombre; set => Nombre = value; }
        public string _Cedula { get => Cedula; set => Cedula = value; }
        public string _Direccion { get => Direccion; set => Direccion = value; }
        public string _Telefono { get => Telefono; set => Telefono = value;}
        public string _Estado { get => Estado; set => Estado = value; }

         public string InsertarTutor(CDTutor objTutor)
            { 

                string mensaje = "";
                SqlConnection sqlCon = new SqlConnection();

                try
                {

                    sqlCon.ConnectionString = Sistema_Conexion.miconexion;
                    SqlCommand micomando = new SqlCommand("TutorInsertar", sqlCon);
                    sqlCon.Open();
                    micomando.CommandType = CommandType.StoredProcedure;

                    micomando.Parameters.AddWithValue("@pIdTutor", objTutor.IdTutor);
                    micomando.Parameters.AddWithValue("@pNombre", objTutor.Nombre);
                    micomando.Parameters.AddWithValue("@pApellidos", objTutor.Apellidos);
                    micomando.Parameters.AddWithValue("@pCedula", objTutor.Cedula);
                    micomando.Parameters.AddWithValue("@pTelefono", objTutor.Telefono);
                    micomando.Parameters.AddWithValue("@pDireccion", objTutor.Direccion);
                    micomando.Parameters.AddWithValue("@pEstado", objTutor.Estado);

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


                public string ActualizarTutor(CDTutor objTutor)
                {

                    string mensaje = "";
                    SqlConnection sqlCon = new SqlConnection(); 

                   try
                    {
                        
                        sqlCon.ConnectionString = Sistema_Conexion.miconexion;
                        SqlCommand micomando = new SqlCommand("TutorActualizar", sqlCon);
                        sqlCon.Open();

                         micomando.Parameters.AddWithValue("@pIdTutor", objTutor.IdTutor);
                        micomando.Parameters.AddWithValue("@pNombre", objTutor.Nombre);
                        micomando.Parameters.AddWithValue("@pApellidos", objTutor.Apellidos);
                        micomando.Parameters.AddWithValue("@pCedula", objTutor.Cedula);
                        micomando.Parameters.AddWithValue("@pTelefono", objTutor.Telefono);
                        micomando.Parameters.AddWithValue("@pDireccion", objTutor.Direccion);
                        micomando.Parameters.AddWithValue("@pEstado", objTutor.Estado);

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


         public string DataTableTutor(string miparametro)
            {
                DataTable dt = new DataTable(); // Creacion de la tabla que muestra el cargo
                SqlDataReader leerDatos; //Creacion del data Reader

                try
                {
                    SqlCommand sqlCmd = new SqlCommand(); //Establece un comando
                    sqlCmd.Connection = new Sistema_Conexion().dbconexion;//Conexion que usara el comando
                    sqlCmd.Connection.Open();// Abrir la base de datos
                    sqlCmd.CommandText = "TutorConsultar"; //Nombre de proc. Almacenado
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
