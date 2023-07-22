using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inscripcion
{
    public partial class FMantenimientoUsuario : Form
    {
        public FMantenimientoUsuario()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FMantenimientoUsuario_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          MessageBox.Show("El dato indicado no existe", "Aviso del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}
