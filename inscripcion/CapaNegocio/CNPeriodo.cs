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
    public class CNPeriodo
    {
        public static string InsertarPeriodo(string PeriodoEscolar, string Slogan, string Desde, string Hasta, string Estado)
        {
            CDPeriodo objPeriodo = new CDPeriodo();

            objPeriodo._PeriodoEscolar = PeriodoEscolar;
            objPeriodo._Slogan = Slogan;
            objPeriodo._Desde = Desde;
            objPeriodo._Hasta = Hasta;
            objPeriodo._Estado = Estado;

            return objPeriodo.InsertarPeriodo(objPeriodo);
        }

        public static string ActualizarPeriodo(int IdPeriodo, string PeriodoEscolar, string Slogan, string Desde, string Hasta, string Estado)
        {
            CDPeriodo objPeriodo = new CDPeriodo();

            objPeriodo._IdPeriodo = IdPeriodo;
            objPeriodo._PeriodoEscolar = PeriodoEscolar;
            objPeriodo._Slogan = Slogan;
            objPeriodo._Desde = Desde;
            objPeriodo._Hasta = Hasta;
            objPeriodo._Estado = Estado;

            return objPeriodo.ActualizarPeriodo(objPeriodo);
        }

        public DataTable ObtenerPeriodo(string miparametro)
        {
            CDPeriodo objPeriodo = new CDPeriodo();
            DataTable dt = new DataTable();

            dt = objPeriodo.DataTablePeriodo(miparametro);

            return dt;
        }






    }
}
