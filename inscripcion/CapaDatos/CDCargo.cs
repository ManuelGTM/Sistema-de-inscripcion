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
        private string Cargo;
        private string Estado;


        //Creacion del constructor de la clase 

        CDCargo(int IdCargo, string Cargo, string Estado) 
        {
            this.IdCargo = IdCargo;
            this.Cargo = Cargo;
            this.Estado = Estado;
        }

        // Definicion de los getters y setters 
        // Clasificados por regiones

        public int _IdCargo 
        {
            get { return IdCargo; }
            set { IdCargo = value; }
        }

        public string _Cargo 
        {
            get { return Cargo; }
            set { Cargo = value; }
        }

        public string _Estado 
        {
            get { return Estado; }
            set { Estado = value; }
        }

        public object SqlCon { get; private set; }

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

                micomando.Parameters.AddWithValue("@pIdCargo",objCargo.IdCargo);
                micomando.Parameters.AddWithValue("@pCargo", objCargo.Cargo);
                micomando.Parameters.AddWithValue("@pEstado",objCargo.Estado);

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

                micomando.Parameters.AddWithValue("@pIdCargo",objCargo.IdCargo);
                micomando.Parameters.AddWithValue("@pCargo", objCargo.Cargo);
                micomando.Parameters.AddWithValue("@pEstado",objCargo.Estado);

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



    }
}
