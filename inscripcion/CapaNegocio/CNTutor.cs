using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;
using CapaDatos;

namespace CapaNegocio
{
    public class CNTutor
    {
        public static string InsertarTutor(int IdTutor, string Nombre, string Apellidos, string Telefono, string Cedula, string Direccion, string Estado)
        {

            CDTutor objTutor = new CDTutor();

            objTutor._Nombre = Nombre;
            objTutor._Apellidos = Apellidos;
            objTutor._Cedula = Cedula;   
            objTutor._Telefono = Telefono;
            objTutor._Direccion = Direccion;
            objTutor._Estado = Estado;  
               
            return objTutor.InsertarTutor(objTutor);

        }


        public static string ActualizarTutor(int IdTutor, string Nombre, string Apellidos, string Telefono, string Cedula, string Direccion, string Estado)
        {

            CDTutor objTutor = new CDTutor();

            objTutor._IdTutor = IdTutor;
            objTutor._Nombre = Nombre;
            objTutor._Apellidos = Apellidos;
            objTutor._Cedula = Cedula;   
            objTutor._Telefono = Telefono;
            objTutor._Direccion = Direccion;
            objTutor._Estado = Estado;  
               
            return objTutor.ActualizarTutor(objTutor);

        }


        public DataTable ObtenerTutor(string miparametro)
        {
            CDTutor objTutor = new CDTutor();
            DataTable dt = new DataTable();

            dt = objTutor.DataTableTutor(miparametro);

            return dt;
        }






    }
}
