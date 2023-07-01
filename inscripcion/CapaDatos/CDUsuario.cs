using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;
using System.Data;
using System.Net.Http.Headers;

namespace CapaDatos
{
    public class CDUsuario
    {

        private int IdUsuario;
        private string Usuario;
        private string Clave;
        private int IdEmpleado;
        private int Nivel;
        private string Estado;

        public CDUsuario()
        {

        }

        public CDUsuario(int IdUsuario, string Usuario, string Clave, int IdEmpleado, int Nivel, string Estado) 
        {
            this.IdUsuario = IdUsuario;
            this.Usuario = Usuario;
            this.Clave = Clave;
            this.IdEmpleado = IdEmpleado;
            this.Nivel = Nivel; 
            this.Estado = Estado;

        }

        
        public int _IdUsuario { get => IdUsuario; set => IdUsuario = value; }
        public string _Usuario { get => Usuario; set => Usuario = value; }
        public string _Clave { get => Clave; set => Clave = value; }
        public int _IdEmpleado { get => IdEmpleado; set => IdEmpleado = value; }
        public int _Nivel { get => Nivel; set => Nivel = value; }
        public string _Estado { get => Estado; set => Estado = value; }

        

         public string InsertarUsuario(CDUsuario objUsuario)
        {

            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {

                sqlCon.ConnectionString = Sistema_Conexion.miconexion;
                SqlCommand micomando = new SqlCommand("UsuarioInsertar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@pIdUsuario", objUsuario.IdUsuario);
                micomando.Parameters.AddWithValue("@pUsuario", objUsuario.Usuario);
                micomando.Parameters.AddWithValue("@pClave", objUsuario.Clave);
                micomando.Parameters.AddWithValue("@pIdEmpleado", objUsuario.IdEmpleado);
                micomando.Parameters.AddWithValue("@pNivel", objUsuario.Nivel);
                micomando.Parameters.AddWithValue("@pEstado", objUsuario.Estado);

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


        public string ActualizarUsuario(CDUsuario objUsuario)
        {

            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {

                sqlCon.ConnectionString = Sistema_Conexion.miconexion;
                SqlCommand micomando = new SqlCommand("UsuarioActualizar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@pIdUsuario", objUsuario.IdUsuario);
                micomando.Parameters.AddWithValue("@pUsuario", objUsuario.Usuario);
                micomando.Parameters.AddWithValue("@pClave", objUsuario.Clave);
                micomando.Parameters.AddWithValue("@pIdEmpleado", objUsuario.IdEmpleado);
                micomando.Parameters.AddWithValue("@pNivel", objUsuario.Nivel);
                micomando.Parameters.AddWithValue("@pEstado", objUsuario.Estado);

                mensaje = micomando.ExecuteNonQuery() == 1 ? "Datos actualizados correctamente"
                                                             : "No se pudo actualizar correctamente los nuevos datos";

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

        public string DataTableUsuario(string miparametro)
        {
                DataTable dt = new DataTable(); // Creacion de la tabla que muestra el cargo
                SqlDataReader leerDatos; //Creacion del data Reader

                try
                {
                    SqlCommand sqlCmd = new SqlCommand(); //Establece un comando
                    sqlCmd.Connection = new Sistema_Conexion().dbconexion;//Conexion que usara el comando
                    sqlCmd.Connection.Open();// Abrir la base de datos
                    sqlCmd.CommandText = "UsuarioConsultar"; //Nombre de proc. Almacenado
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
