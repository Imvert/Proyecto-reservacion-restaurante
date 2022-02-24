using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project_restaurant_reservation
{
    public partial class Login : Form
    {
        int contador = 1;
        //cadena de conexion
        SqlConnection con = new SqlConnection("Data Source = LAPTOPALEX; Initial Catalog = restaurante; Integrated Security = True");


        public Login()
        {
            InitializeComponent();
        }

        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_usuario.Text) || string.IsNullOrEmpty(txt_contraseña.Text))
            {
                MessageBox.Show("Campos vacios !!");
            }
            else
            {
                loguear(txt_usuario.Text, txt_contraseña.Text);
            }
        }

        private void loguear(string usuario, string pass)
        {
            try
            {

                //Verificar datos si existen o no usuario
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT usu_nombre, tusu_id FROM tbl_usuario WHERE usu_nomlogin = @usuario", con);
                cmd.Parameters.AddWithValue("usuario", usuario);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();

                //Comparando usuario de la base de datos y la contraseña encriptada
                if (dt.Rows.Count == 1)
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("SELECT usu_nombre, tusu_id FROM tbl_usuario WHERE usu_nomlogin = @usuario and usu_password = @passw", con);
                    cmd1.Parameters.AddWithValue("usuario", usuario);
                    cmd1.Parameters.AddWithValue("passw", pass);
                    SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);
                    con.Close();

                    if (dt1.Rows.Count == 1)
                    {
                        this.Hide();
                        if (dt1.Rows[0][1].ToString() == "1")//administrador
                        {
                            new plantilla_Admin().ShowDialog();
                        }
                        else if (dt1.Rows[0][1].ToString() == "2")//Cliente
                        {
                            new PlantUsuarios().ShowDialog();
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Datos incorrectos..!!!");
                        lbl_intentos.Text = contador.ToString();
                        contador++;

                        if (lbl_intentos.Text == "3")
                        {
                            MessageBox.Show("Ha superado el maximo de intentos Usuario Bloqueado");
                            btn_ingresar.Enabled = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Usuario no existente");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            new Registro_usuarios().ShowDialog();
            this.Hide();
            this.Close();
        }
    }
}
