using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;
using System.Data;
using System.Reflection.Emit;

namespace CapaDatos
{
    public class CDEmpleado
    {
        //Atributos de Empleado

        private int IdEmpleado;
        private string Nombre;
        private string Apellidos;
        private string Cedula;
        private string Telefono;
        private string Direccion;
        private int IdDepartamento;
        private int IdCargo;
        private string Estado;

        public CDEmpleado()
        {
        }

        public CDEmpleado(int Empleado, string Nombre, string Apellidos, string Cedula, string Telefono ,string Direccion, int IdDepartamento, int IdCargo, string Estado) {

            this.IdEmpleado = Empleado;
            this.Nombre = Nombre;
            this.Apellidos = Apellidos;
            this.Cedula = Cedula;
            this.Telefono = Telefono;
            this.Direccion = Direccion;
            this.IdDepartamento = IdDepartamento;
            this.IdCargo = IdCargo;
            this.Estado = Estado;
        }

        // getters y setters
        public int _IdEmpleado { get => IdEmpleado; set => IdEmpleado = value; }
        public string _Nombre { get => Nombre; set => Nombre = value; }

        public string _Apellidos { get => Apellidos; set => Apellidos = value; }
        public string _Cedula { get => Cedula; set => Cedula = value; }
        public string _Telefono { get => Telefono; set => Telefono = value;}
        public string _Direccion { get => Direccion; set => Direccion = value; }
        public int _IdDepartamento { get => IdDepartamento; set => IdDepartamento = value;}
        public int _IdCargo { get => IdCargo; set => IdCargo = value; }
        public string _Estado { get => Estado; set => Estado = value; }

        

         public string InsertarEmpleado(CDEmpleado objEmpleado)
            { 

                string mensaje = "";
                SqlConnection sqlCon = new SqlConnection();

                try
                {

                    sqlCon.ConnectionString = Sistema_Conexion.miconexion;
                    SqlCommand micomando = new SqlCommand("EmpleadoInsertar", sqlCon);
                    sqlCon.Open();
                    micomando.CommandType = CommandType.StoredProcedure;

                    micomando.Parameters.AddWithValue("@pIdEmpleado", objEmpleado._IdEmpleado);
                    micomando.Parameters.AddWithValue("@pNombre", objEmpleado._Nombre);
                    micomando.Parameters.AddWithValue("@pApellidos", objEmpleado._Apellidos);
                    micomando.Parameters.AddWithValue("@pCedula", objEmpleado._Cedula);
                    micomando.Parameters.AddWithValue("@pTelefono", objEmpleado._Telefono);
                    micomando.Parameters.AddWithValue("@pDireccion", objEmpleado._Direccion);
                    micomando.Parameters.AddWithValue("@pIdDepartamento", objEmpleado._IdDepartamento);
                    micomando.Parameters.AddWithValue("@pIdCargo", objEmpleado._IdCargo);
                    micomando.Parameters.AddWithValue("@pEstado", objEmpleado._Estado);

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

         public string ActualizarEmpleado(CDEmpleado objEmpleado)
                {

                    string mensaje = "";
                    SqlConnection sqlCon = new SqlConnection(); 

                   try
                    {
                        
                        sqlCon.ConnectionString = Sistema_Conexion.miconexion;
                        SqlCommand micomando = new SqlCommand("EmpleadoActualizar", sqlCon);
                        sqlCon.Open();

                        micomando.Parameters.AddWithValue("@pIdEmpleado", objEmpleado._IdEmpleado);
                        micomando.Parameters.AddWithValue("@pNombre", objEmpleado._Nombre);
                        micomando.Parameters.AddWithValue("@pApellidos", objEmpleado._Apellidos);
                        micomando.Parameters.AddWithValue("@pCedula", objEmpleado._Cedula);
                        micomando.Parameters.AddWithValue("@pTelefono", objEmpleado._Telefono);
                        micomando.Parameters.AddWithValue("@pDireccion", objEmpleado._Direccion);
                        micomando.Parameters.AddWithValue("@pIdDepartamento", objEmpleado._IdDepartamento);
                        micomando.Parameters.AddWithValue("@pIdCargo", objEmpleado._IdCargo);
                        micomando.Parameters.AddWithValue("@pEstado", objEmpleado._Estado);

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


         public string DataTableEmpleado(string miparametro)
            {
                DataTable dt = new DataTable(); // Creacion de la tabla que muestra el cargo
                SqlDataReader leerDatos; //Creacion del data Reader

                try
                {
                    SqlCommand sqlCmd = new SqlCommand(); //Establece un comando
                    sqlCmd.Connection = new Sistema_Conexion().dbconexion;//Conexion que usara el comando
                    sqlCmd.Connection.Open();// Abrir la base de datos
                    sqlCmd.CommandText = "EmpleadoConsultar"; //Nombre de proc. Almacenado
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
