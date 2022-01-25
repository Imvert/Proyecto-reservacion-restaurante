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
    public partial class Registro_usuarios : Form
    {
        //cadena de conexion
        SqlConnection con = new SqlConnection("Data Source = LAPTOPALEX; Initial Catalog = restaurante; Integrated Security = True");

        public Registro_usuarios()
        {
            InitializeComponent();
        }

        //funcion para registrar usuarios
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_ced.Text) || string.IsNullOrEmpty(txt_correo.Text) || string.IsNullOrEmpty(txt_direc.Text) || string.IsNullOrEmpty(txt_nick.Text) || string.IsNullOrEmpty(txt_nombre.Text) || string.IsNullOrEmpty(txt_pass.Text) || string.IsNullOrEmpty(txt_telf.Text))
            {
                MessageBox.Show("No debe haber campos vacios !!");
            }
            else
            {
               registrar(txt_nombre.Text, txt_ced.Text,txt_nick.Text,txt_pass.Text,txt_direc.Text,txt_correo.Text,txt_telf.Text);
                limpiar();
                MessageBox.Show("Usuario registrado !!");
            }
            

        }
        private void limpiar()
        {
            txt_ced.Text = txt_correo.Text = txt_direc.Text = txt_nick.Text = txt_nombre.Text = txt_pass.Text = txt_telf.Text = "";
        
        }

        private void btn_regresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            new Login().ShowDialog();
        }

        private void registrar(string nom, string cedula, string nick, string pass, string direccion,string correo,string telefono)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_usuario (usu_nombre,usu_cedula,usu_nomlogin,usu_password,usu_direccion,usu_correo,usu_estado,usu_telefono,tusu_id) VALUES(@nomb,@ced,@nick,@pass,@dire,@correo,@estado,@telf,@rol)", con);
                cmd.Parameters.AddWithValue("nomb", nom);
                cmd.Parameters.AddWithValue("ced", cedula);
                cmd.Parameters.AddWithValue("nick", nick);
                cmd.Parameters.AddWithValue("pass", pass);
                cmd.Parameters.AddWithValue("dire", direccion);
                cmd.Parameters.AddWithValue("correo", correo);
                cmd.Parameters.AddWithValue("estado", 'A');
                cmd.Parameters.AddWithValue("telf", telefono);
                cmd.Parameters.AddWithValue("rol", "2");
                cmd.ExecuteNonQuery();
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //sda.Fill(dt);
                con.Close();

            }
            catch (Exception ex)
            {
                
            }
        
        
        }
    }
}
