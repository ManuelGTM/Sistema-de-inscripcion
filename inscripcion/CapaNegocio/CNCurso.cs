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
    public class CNCurso
    {
        public static string InsertarCurso(string Grado, string Seccion, int idTutor, string Estado)
        {
            CDCurso objCurso = new CDCurso();

            objCurso._Grado = Grado;
            objCurso._Seccion = Seccion;
            objCurso._IdTutor = idTutor;
            objCurso._Estado = Estado;

            return objCurso.InsertarCurso(objCurso);
        }

        public static string ActualizarCurso(int IdCurso, string Grado, string Seccion, int idTutor, string Estado)
        {
            CDCurso objCurso = new CDCurso();

            objCurso._IdCurso = IdCurso;
            objCurso._Grado = Grado;
            objCurso._Seccion = Seccion;
            objCurso._IdTutor = idTutor;
            objCurso._Estado = Estado;

            return objCurso.ActualizarCurso(objCurso);
        }

        public DataTable ObtenerCurso(string miparametro)
        {
            CDCurso objCurso = new CDCurso();
            DataTable dt = new DataTable();

            dt = objCurso.DataTableCurso(miparametro);

            return dt;
        }

    }
}
