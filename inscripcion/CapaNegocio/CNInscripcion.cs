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
    public class CNInscripcion
    {
        public static string InsertarInscripcion(int IdEscuela, int IdPeriodo, int IdEstudiante, int IdEmpleado, int IdCurso, string Fecha, string Estado)
        {

            CDInscripcion objInscripcion = new CDInscripcion();
            objInscripcion._IdEscuela = IdEscuela;
            objInscripcion._IdPeriodo = IdPeriodo;
            objInscripcion._IdEstudiante = IdEstudiante;
            objInscripcion._IdCurso = IdCurso;
            objInscripcion._Fecha = Fecha;
            objInscripcion._Estado = Estado;

            return objInscripcion.InsertarInscripcion(objInscripcion);

        }

        public static string ActualizarInscripcion(int IdInscripcion, int IdEscuela, int IdPeriodo, int IdEstudiante, int IdEmpleado, int IdCurso, string Fecha, string Estado)
        {

            CDInscripcion objInscripcion = new CDInscripcion();
            objInscripcion._IdInscripcion = IdInscripcion;
            objInscripcion._IdEscuela = IdEscuela;
            objInscripcion._IdPeriodo = IdPeriodo;
            objInscripcion._IdEstudiante = IdEstudiante;
            objInscripcion._IdCurso = IdCurso;
            objInscripcion._Fecha = Fecha;
            objInscripcion._Estado = Estado;

            return objInscripcion.ActualizarInscripcion(objInscripcion);

        }

          public DataTable ObtenerInscripcion(string miparametro)
                {
                    CDInscripcion objInscripcion = new CDInscripcion();
                    DataTable dt = new DataTable();

                    dt = objInscripcion.DataTableInscripcion(miparametro);

                    return dt;
                }



    }
}
