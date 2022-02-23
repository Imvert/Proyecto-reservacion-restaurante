using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_restaurant_reservation
{
    public partial class plantilla : Form
    {
        public plantilla()
        {
            InitializeComponent();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // Usuario usu = new Usuario();
            //usu.MdiParent = this;
            //usu.Show();
        }

        private void mesasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reserva rs = new Reserva();
            rs.MdiParent = this;
            rs.Show();

        }

        private void tipoPlatoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tipoplato tp = new tipoplato();
            tp.MdiParent = this;
            tp.Show();
        }

        private void tipoUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

            tipoUsuario tU = new tipoUsuario();
            tU.MdiParent = this;
            tU.Show();
        }

        private void tipoServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

       
        private void usuariosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Usuario usu = new Usuario();
            usu.MdiParent = this;
            usu.Show();

        }

        private void platosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registro_platos rp = new Registro_platos();
            rp.MdiParent = this;
            rp.Show();
        }

        //Este no tocar ni poner nada
        private void mantenimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
