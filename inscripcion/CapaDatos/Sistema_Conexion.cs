using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace CapaDatos
{
    public class Sistema_Conexion
    {
        public static string miconexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:
                                    \Users\rapto\WorkBench\Sistema_de_inscripcion\Sistema-de-inscripcion\inscripcion\CapaDatos\DBInscripcion.mdf;Integrated Security = True";

        public SqlConnection dbconexion = new SqlConnection(miconexion);
    }
}
