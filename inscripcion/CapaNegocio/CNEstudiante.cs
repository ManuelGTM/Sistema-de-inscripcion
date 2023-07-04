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
    public class CNEstudiante
    {
        public static string InsertarEstudiante(string Nombre, string Apellido, int IdTutor, int IdCurso, string Sexo, string FechaNacimiento, string Direccion, string Estado)
        {
            CDEstudiante objEstudiante = new CDEstudiante();

            objEstudiante._Nombre = Nombre;
            objEstudiante._Apellido = Apellido;
            objEstudiante._IdTutor = IdTutor;
            objEstudiante._IdCurso = IdCurso;
            objEstudiante._Sexo = Sexo;
            objEstudiante._FechaNacimiento = FechaNacimiento;
            objEstudiante._Direccion = Direccion;
            objEstudiante._Estado = Estado;
            
            return objEstudiante.InsertarEstudiante(objEstudiante);
        }

        public static string ActualizarEstudiante(int IdEstudiante, string Nombre, string Apellido, int IdTutor, int IdCurso, string Sexo, string FechaNacimiento, string Direccion, string Estado)
        {
            CDEstudiante objEstudiante = new CDEstudiante();

            objEstudiante._IdEstudiante = IdEstudiante;
            objEstudiante._Nombre = Nombre;
            objEstudiante._Apellido = Apellido;
            objEstudiante._IdTutor = IdTutor;
            objEstudiante._IdCurso = IdCurso;
            objEstudiante._Sexo = Sexo;
            objEstudiante._FechaNacimiento = FechaNacimiento;
            objEstudiante._Direccion = Direccion;
            objEstudiante._Estado = Estado;
            
            return objEstudiante.ActualizarEstudiante(objEstudiante);
        }

        public DataTable ObtenerEstudiante(string miparametro)
        {
            CDEstudiante objEstudiante = new CDEstudiante();
            DataTable dt = new DataTable();

            dt = objEstudiante.DataTableEstudiante(miparametro);

            return dt;
        }









    }
}
