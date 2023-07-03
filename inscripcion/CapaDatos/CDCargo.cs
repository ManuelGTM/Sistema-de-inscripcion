using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;


namespace CapaDatos
{
    public class CDCargo
    {
        // Definicion de los atributos de la clase
        private int IdCargo;
        private string NombreCargo;
        private string Estado;

        // Creacion de un constructor vacío

        public CDCargo() 
        { 
        
        }

        //Creacion del constructor de la clase 

        public CDCargo(int IdCargo, string Cargo, string Estado) 
        {
            this.IdCargo = IdCargo;
            this.NombreCargo = Cargo;
            this.Estado = Estado;
        }

        // Definicion de los getters y setters 
        // Clasificados por regiones

        public int _IdCargo 
        {
            get { return IdCargo; }
            set { IdCargo = value; }
        }

        public string _NombreCargo 
        {
            get { return NombreCargo; }
            set { NombreCargo = value; }
        }

        public string _Estado 
        {
            get { return Estado; }
            set { Estado = value; }
        }
 
        public string InsertarCargo(CDCargo objCargo)
        {

            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection(); 

            try
            {
                
                sqlCon.ConnectionString = Sistema_Conexion.miconexion;
                SqlCommand micomando = new SqlCommand("CargoInsertar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@pIdCargo",objCargo._IdCargo);
                micomando.Parameters.AddWithValue("@pCargo", objCargo._NombreCargo);
                micomando.Parameters.AddWithValue("@pEstado",objCargo._Estado);

                mensaje = micomando.ExecuteNonQuery() == 1?"Insercion de datos completada correctamente"
                                                             :"No se pudo insertar correctamente los nuevos datos";

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


        
        public string ActualizarCargo(CDCargo objCargo)
        {

            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection(); 

           try
            {
                
                sqlCon.ConnectionString = Sistema_Conexion.miconexion;
                SqlCommand micomando = new SqlCommand("CargoActualizar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@pIdCargo",objCargo._IdCargo);
                micomando.Parameters.AddWithValue("@pNombreCargo", objCargo._NombreCargo);
                micomando.Parameters.AddWithValue("@pEstado",objCargo._Estado);

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


        public string DataTableCargo(string miparametro)
        {
            DataTable dt = new DataTable(); // Creacion de la tabla que muestra el cargo
            SqlDataReader leerDatos; //Creacion del data Reader

            try
            {
                SqlCommand sqlCmd = new SqlCommand(); //Establece un comando
                sqlCmd.Connection = new Sistema_Conexion().dbconexion;//Conexion que usara el comando
                sqlCmd.Connection.Open();// Abrir la base de datos
                sqlCmd.CommandText = "CargoConsultar"; //Nombre de proc. Almacenado
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
