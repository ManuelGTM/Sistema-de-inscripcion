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
    public class CNEscuela
    {
        public static string InsertarEscuela (string Nombre, int DistritoEducativo, int Regional, int CodigoMinerd, string Director, string Estado)
        {
            CDEscuela objEscuela = new CDEscuela();

            objEscuela._Nombre = Nombre;
            objEscuela._DistritoEducativo = DistritoEducativo;
            objEscuela._Regional = Regional;
            objEscuela._CodigoMinerd = CodigoMinerd;
            objEscuela._Director = Director;
            objEscuela._Estado = Estado;

            return objEscuela.InsertarEscuela(objEscuela);
        }


        public static string ActualizarEscuela (int IdEscuela, string Nombre, int DistritoEducativo, int Regional, int CodigoMinerd, string Director, string Estado)
        {
            CDEscuela objEscuela = new CDEscuela();

            objEscuela._IdEscuela = IdEscuela;
            objEscuela._Nombre = Nombre;
            objEscuela._DistritoEducativo = DistritoEducativo;
            objEscuela._Regional = Regional;
            objEscuela._CodigoMinerd = CodigoMinerd;
            objEscuela._Director = Director;
            objEscuela._Estado = Estado;

            return objEscuela.ActualizarEscuela(objEscuela);
        }

       public DataTable ObtenerEscuela(string miparametro)
            {
                CDEscuela objEscuela = new CDEscuela();
                DataTable dt = new DataTable();

                dt = objEscuela.DataTableEscuela(miparametro);

                return dt;
            }




    }

}
