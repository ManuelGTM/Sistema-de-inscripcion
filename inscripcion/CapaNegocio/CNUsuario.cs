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
    public class CNUsuario
    {
        public static string InsertarUsuario(string Usuario, string Clave, int IdEmpleado, int Nivel, string Estado)
        {
            CDUsuario objUsuario = new CDUsuario();
             
            objUsuario._Usuario = Usuario;
            objUsuario._Clave = Clave;
            objUsuario._IdEmpleado = IdEmpleado;
            objUsuario._Nivel = Nivel;
            objUsuario._Estado = Estado;
            
            return "";
        }

        public static string ActualizarUsuario(int IdUsuario, string Usuario, string Clave, int IdEmpleado, int Nivel, string Estado)
        {
            CDUsuario objUsuario = new CDUsuario();

            objUsuario._IdUsuario = IdUsuario;
            objUsuario._Usuario = Usuario;
            objUsuario._Clave = Clave;
            objUsuario._IdEmpleado = IdEmpleado;
            objUsuario._Nivel = Nivel;
            objUsuario._Estado = Estado;
            
            return "";
        } 


        public DataTable ObtenerUsuario(string miparametro)
        {
            CDUsuario objUsuario = new CDUsuario();
            DataTable dt = new DataTable();

            dt = objUsuario.DataTableUsuario(miparametro);

            return dt;
        }







    }
}
