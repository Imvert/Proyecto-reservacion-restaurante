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
    public partial class plantilla_Admin : Form
    {
        public plantilla_Admin()
        {
            InitializeComponent();
            Diseño();
        }

        private void plantilla_Load(object sender, EventArgs e)
        {

        }

        private void Diseño()
        {
            panelManteSubMenu.Visible = false;
            
        }

        private void hideSubMenu()
        {
            if (panelManteSubMenu.Visible == true)
                panelManteSubMenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;

            }
        }

        private Form activateForm = null;

        //crea un contentenedor padre para almacenar un formulario hijo
        private void openChildForm(Form childForm)
        {
            if (activateForm != null)
                activateForm.Close();
            activateForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelchild.Controls.Add(childForm);
            panelchild.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btn_Mantenimiento_Click(object sender, EventArgs e)
        {
            showSubMenu(panelManteSubMenu);
        }

        //tabla usuarios
        private void btn_Tusuario_Click(object sender, EventArgs e)
        {
            openChildForm(new Usuario());
            hideSubMenu();

        }

        private void btn_roles_Click(object sender, EventArgs e)
        {
            openChildForm(new tipoUsuario());
            hideSubMenu();
        }

        private void btn_Treservas_Click(object sender, EventArgs e)
        {
            openChildForm(new Reserva());
            hideSubMenu();

        }

        //registro platos
        private void btn_Tplatos_Click(object sender, EventArgs e)
        {
            openChildForm(new Registro_platos());
            hideSubMenu();
        }

        //tipo de platos
        private void btn_TiPlatos_Click(object sender, EventArgs e)
        {
            openChildForm(new tipoplato());
            hideSubMenu();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que quiere salir de la aplicacion?", "Cuidado",
              MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                //Application.Exit();
                this.Close();
        }
    }
}
