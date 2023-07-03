using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;
using System.Data;
using System.Runtime.InteropServices;

namespace CapaDatos
{
    public class CDInscripcion
    {

        int IdInscripcion;
        int IdEscuela;
        int IdPeriodo;
        int IdEstudiante;
        int IdEmpleado;
        int IdCurso;
        string Fecha;
        string Estado;

        public CDInscripcion()
        {

        }


        public CDInscripcion(int IdInscripcion, int IdEscuela, int IdPeriodo, int IdEstudiante, int IdEmpleado, int IdCurso, string Fecha, string Estado)
        {

            this.IdInscripcion = IdInscripcion;
            this.IdEscuela = IdEscuela;
            this.IdPeriodo = IdPeriodo;
            this.IdEstudiante = IdEstudiante;
            this.IdCurso = IdCurso;
            this.Fecha = Fecha;
            this.Estado = Estado;
        }


        public int _IdInscripcion { get => IdInscripcion; set => IdInscripcion = value; }
        public int _IdEscuela { get => IdEscuela; set => IdEscuela = value; }
        public int _IdPeriodo { get => IdPeriodo; set => IdPeriodo = value; }
        public int _IdEstudiante { get => IdEstudiante; set => IdEstudiante = value; }
        public int _IdEmpleado { get => IdEmpleado; set => IdEmpleado = value; }
        public int _IdCurso { get => IdCurso; set => IdCurso = value; }
        public string _Fecha { get => Fecha; set => Fecha = value; }
        public string _Estado { get => Estado; set => Estado = value; }


      public string InsertarInscripcion(CDInscripcion objInscripcion)
            {

                string mensaje = "";
                SqlConnection sqlCon = new SqlConnection();

            try
            {

                sqlCon.ConnectionString = Sistema_Conexion.miconexion;
                SqlCommand micomando = new SqlCommand("InscripcionInsertar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@pIdInscripcion", objInscripcion._IdInscripcion);
                micomando.Parameters.AddWithValue("@pIdEscuela", objInscripcion._IdEscuela);
                micomando.Parameters.AddWithValue("@pIdPeriodo", objInscripcion._IdPeriodo);
                micomando.Parameters.AddWithValue("@pIdEmpleado", objInscripcion._IdEmpleado);
                micomando.Parameters.AddWithValue("@pIdCurso", objInscripcion._IdCurso);
                micomando.Parameters.AddWithValue("@pFecha", objInscripcion._Fecha);
                micomando.Parameters.AddWithValue("@pEstado", objInscripcion._Estado);

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

         public string ActualizarInscripcion(CDInscripcion objInscripcion)
                {

                    string mensaje = "";
                    SqlConnection sqlCon = new SqlConnection(); 

                   try
                    {
                        
                        sqlCon.ConnectionString = Sistema_Conexion.miconexion;
                        SqlCommand micomando = new SqlCommand("InscripcionActualizar", sqlCon);
                        sqlCon.Open();

                        micomando.Parameters.AddWithValue("@pIdInscripcion", objInscripcion._IdInscripcion);
                        micomando.Parameters.AddWithValue("@pIdEscuela", objInscripcion._IdEscuela);
                        micomando.Parameters.AddWithValue("@pIdPeriodo", objInscripcion._IdPeriodo);
                        micomando.Parameters.AddWithValue("@pIdEmpleado", objInscripcion._IdEmpleado);
                        micomando.Parameters.AddWithValue("@pIdCurso", objInscripcion._IdCurso);
                        micomando.Parameters.AddWithValue("@pFecha", objInscripcion._Fecha);
                        micomando.Parameters.AddWithValue("@pEstado", objInscripcion._Estado);

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


         public DataTable DataTableInscripcion(string miparametro)
            {
                DataTable dt = new DataTable(); // Creacion de la tabla que muestra el cargo
                SqlDataReader leerDatos; //Creacion del data Reader

                try
                {
                    SqlCommand sqlCmd = new SqlCommand(); //Establece un comando
                    sqlCmd.Connection = new Sistema_Conexion().dbconexion;//Conexion que usara el comando
                    sqlCmd.Connection.Open();// Abrir la base de datos
                    sqlCmd.CommandText = "InscripcionConsultar"; //Nombre de proc. Almacenado
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
