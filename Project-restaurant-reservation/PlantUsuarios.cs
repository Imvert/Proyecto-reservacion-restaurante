﻿using System;
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
    public partial class PlantUsuarios : Form
    {
        public PlantUsuarios()
        {
            InitializeComponent();
            Diseño();
        }

        private void PlantUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void Diseño()
        {
            PanelMenuSubMenu.Visible = false;
            panelActividadSubMenu.Visible = false;
        }

        private void hideSubMenu()
        {
            if (PanelMenuSubMenu.Visible == true)
                PanelMenuSubMenu.Visible = false;

            if (panelActividadSubMenu.Visible == true)
                panelActividadSubMenu.Visible = false;
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

        private void btn_Menu_Click(object sender, EventArgs e)
        {
            showSubMenu(PanelMenuSubMenu);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Esta funcion permite abrir un formulario nuevo dentro de un contenedor
            openChildForm(new Reserva_mesa());
            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Carta de restaurante
            openChildForm(new Form1());
            hideSubMenu();
        }

        private void btn_ReservasHechas_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btn_Actividad_Click(object sender, EventArgs e)
        {
            showSubMenu(panelActividadSubMenu);
        }


    }
}