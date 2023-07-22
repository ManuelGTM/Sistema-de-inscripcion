using inscripcion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_inscripcion
{
    public partial class Sistema : Form
    {
        public Sistema()
        {
            InitializeComponent();
        }

        private void Sistema_Load(object sender, EventArgs e)
        {

        }

        private void periodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FMantenimientoUsuario FMantUsuario = new FMantenimientoUsuario();
            FMantUsuario.ShowDialog();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FMantenimientoTutor fMantTutor = new FMantenimientoTutor();
            fMantTutor.ShowDialog();
        }

        private void tutorToolStripMenuItem_Click(object sender, EventArgs e)
        {

           FMantenimientoTutor fMantTutor = new FMantenimientoTutor();
            fMantTutor.ShowDialog();
        }

        private void porPeriodoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void porEmpleadoToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            statusStrip1.Items[1].Text = "Fecha/Hora: "+DateTime.Now.ToString();


        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {

        }

        private void inscripcionToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void utilidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void estudianteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FMantenimientoEstudiante fMantEstudiante = new FMantenimientoEstudiante();
            fMantEstudiante.ShowDialog();
        }

        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FMantenimientoEmpleado fMantEmpleado = new FMantenimientoEmpleado();
            fMantEmpleado.ShowDialog();
        }

        private void inscripcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PInscripcionEstudiante pInscripcion = new PInscripcionEstudiante();
            pInscripcion.ShowDialog(); 
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FMantenimientoCurso FMantCurso = new FMantenimientoCurso();
            FMantCurso.ShowDialog();
        }

        private void periodoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
