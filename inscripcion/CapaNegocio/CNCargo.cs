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
    public class CNCargo
    {
        public static string InsertarCargo(string NombreCargo, string Estado)
        {
            CDCargo objCargo = new CDCargo();
            objCargo._NombreCargo = NombreCargo;
            objCargo._Estado = Estado;

            return objCargo.InsertarCargo(objCargo);

        }

        public static string ActualizarCargo(int IdCargo, string NombreCargo, string Estado)
        {
             
            CDCargo objCargo = new CDCargo();
            objCargo._IdCargo = IdCargo;
            objCargo._NombreCargo = NombreCargo;
            objCargo._Estado = Estado;

            return objCargo.ActualizarCargo(objCargo);
            
        }

        
        public DataTable ObtenerCargo(string miparametro)
        {
            CDCargo objCargo = new CDCargo();
            DataTable dt = new DataTable();

            dt = objCargo.DataTableCargo(miparametro);

            return dt;
        }





    }
}
