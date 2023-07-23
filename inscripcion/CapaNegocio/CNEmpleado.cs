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
using System.Security.Cryptography.X509Certificates;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;
using CapaDatos;

namespace CapaNegocio
{
    public class CNEmpleado{
        public static string InsertarEmpleado(string Nombre, string Apellidos, string Cedula, string Telefono, string Direccion, int IdCargo, string Estado)
        {

                CDEmpleado objEmpleado = new CDEmpleado();
                objEmpleado._Nombre = Nombre;
                objEmpleado._Apellidos = Apellidos;
                objEmpleado._Cedula = Cedula;
                objEmpleado._Telefono = Telefono;
                objEmpleado._Direccion = Direccion;
                objEmpleado._IdCargo = IdCargo;
                objEmpleado._Estado = Estado;

                return objEmpleado.InsertarEmpleado(objEmpleado);

        }

        public static string ActualizarEmpleado(int IdEmpleado, string Nombre, string Apellidos, string Cedula, string Telefono, string Direccion, int IdCargo, string Estado)
        {

            CDEmpleado objEmpleado = new CDEmpleado();
            objEmpleado._IdEmpleado = IdEmpleado;
            objEmpleado._Nombre = Nombre;
            objEmpleado._Apellidos = Apellidos;
            objEmpleado._Cedula = Cedula;
            objEmpleado._Telefono = Telefono;
            objEmpleado._Direccion = Direccion;
            objEmpleado._IdCargo = IdCargo;
            objEmpleado._Estado = Estado;

            return objEmpleado.ActualizarEmpleado(objEmpleado);


        }

          public DataTable ObtenerEmpleado(string miparametro)
                {
                    CDEmpleado objEmpleado = new CDEmpleado();
                    DataTable dt = new DataTable();

                    dt = objEmpleado.DataTableEmpleado(miparametro);

                    return dt;
                }

    }
}
