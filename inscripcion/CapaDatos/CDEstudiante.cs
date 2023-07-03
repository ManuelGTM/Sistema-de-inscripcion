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
    public class CDEstudiante
    {

        private int IdEstudiante;
        private string Nombre;
        private string Apellido;
        private int IdTutor;
        private int IdCurso;
        private string Sexo;
        private string FechaNacimiento;
        private string Direccion;
        private string Estado;

        public CDEstudiante() 
        {

        }

        public CDEstudiante(int IdEstudiante, string Nombre, string Apellido, int IdTutor, int IdCurso, string Sexo, string FechaNacimiento, string Direccion, string Estado)    
        {

            this.IdEstudiante = IdEstudiante;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.IdTutor = IdTutor;
            this.IdCurso = IdCurso;
            this.Sexo = Sexo;
            this.FechaNacimiento = FechaNacimiento;
            this.Direccion = Direccion;
            this.Estado = Estado;
        }

        public int _IdEstudiante { get => IdEstudiante; set => IdEstudiante = value; } 
        public string _Nombre { get => Nombre; set => Nombre = value; } 
        public string _Apellido { get => Apellido; set => Apellido = value; } 
        public int _IdTutor { get => IdTutor; set => IdTutor = value; } 
        public int _IdCurso { get => IdCurso; set => IdCurso = value; } 
        public string _Sexo { get => Sexo; set => Sexo = value; } 
        public string _FechaNacimiento { get => FechaNacimiento; set => FechaNacimiento = value; } 
        public string _Direccion { get => Direccion; set => Direccion = value; } 
        public string _Estado { get => Estado; set => Estado = value; } 



         public string InsertarEstudiante(CDEstudiante objEstudiante)
            {

                string mensaje = "";
                SqlConnection sqlCon = new SqlConnection();

                try
                {

                    sqlCon.ConnectionString = Sistema_Conexion.miconexion;
                    SqlCommand micomando = new SqlCommand("EstudianteInsertar", sqlCon);
                    sqlCon.Open();
                    micomando.CommandType = CommandType.StoredProcedure;

                    micomando.Parameters.AddWithValue("@pIdEstudiante", objEstudiante._IdEstudiante);
                    micomando.Parameters.AddWithValue("@pNombre", objEstudiante._Nombre);
                    micomando.Parameters.AddWithValue("@pApellido", objEstudiante._Apellido);
                    micomando.Parameters.AddWithValue("@pIdTutor", objEstudiante._IdTutor);
                    micomando.Parameters.AddWithValue("@pIdCurso", objEstudiante._IdCurso);
                    micomando.Parameters.AddWithValue("@pSexo", objEstudiante._Sexo);
                    micomando.Parameters.AddWithValue("@pFechaNacimiento", objEstudiante._FechaNacimiento);
                    micomando.Parameters.AddWithValue("@pDireccion", objEstudiante._Direccion);
                    micomando.Parameters.AddWithValue("@pEstado", objEstudiante._Estado);

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
        


        public string ActualizarEstudiante(CDEstudiante objEstudiante)
                {

                    string mensaje = "";
                    SqlConnection sqlCon = new SqlConnection();

                    try
                    {

                        sqlCon.ConnectionString = Sistema_Conexion.miconexion;
                        SqlCommand micomando = new SqlCommand("EstudianteActualizar", sqlCon);
                        sqlCon.Open();
                        micomando.CommandType = CommandType.StoredProcedure;

                        micomando.Parameters.AddWithValue("@pIdEstudiante", objEstudiante._IdEstudiante);
                        micomando.Parameters.AddWithValue("@pNombre", objEstudiante._Nombre);
                        micomando.Parameters.AddWithValue("@pApellido", objEstudiante._Apellido);
                        micomando.Parameters.AddWithValue("@pIdTutor", objEstudiante._IdTutor);
                        micomando.Parameters.AddWithValue("@pIdCurso", objEstudiante._IdCurso);
                        micomando.Parameters.AddWithValue("@pSexo", objEstudiante._Sexo);
                        micomando.Parameters.AddWithValue("@pFechaNacimiento", objEstudiante._FechaNacimiento);
                        micomando.Parameters.AddWithValue("@pDireccion", objEstudiante._Direccion);
                        micomando.Parameters.AddWithValue("@pEstado", objEstudiante._Estado);

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


         public DataTable DataTableEstudiante(string miparametro)
                    {
                        DataTable dt = new DataTable(); // Creacion de la tabla que muestra el cargo
                        SqlDataReader leerDatos; //Creacion del data Reader

                        try
                        {
                            SqlCommand sqlCmd = new SqlCommand(); //Establece un comando
                            sqlCmd.Connection = new Sistema_Conexion().dbconexion;//Conexion que usara el comando
                            sqlCmd.Connection.Open();// Abrir la base de datos
                            sqlCmd.CommandText = "EstudianteConsultar"; //Nombre de proc. Almacenado
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
