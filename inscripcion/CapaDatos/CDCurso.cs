using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;
using System.Data;


namespace CapaDatos
{
    public class CDCurso
    {
        int IdCurso;
        string Grado;
        string Seccion;
        int IdTutor;
        string Estado;

        public CDCurso()
        {

        }

        public CDCurso(int IdCurso, string Grado, string Seccion, int idTutor, string Estado)
        {
            this.IdCurso = IdCurso;
            this.Grado = Grado;
            this.Seccion = Seccion;
            this.IdTutor = idTutor;
            this.Estado = Estado;
        }


        public int _IdCurso
        {
            get { return IdCurso; }
            set { IdCurso = value; }
        }

        public string _Grado {
            get { return Grado; }
            set { Grado = value; }
        }

        public string _Seccion {
            get { return Seccion; }
            set { Seccion = value; }
        }

        public int _IdTutor {
            get { return IdTutor; }
            set { IdTutor = value; }
        }

        public string _Estado {
            get { return Estado; }
            set { Estado = value; }
        }

       









    }
}
