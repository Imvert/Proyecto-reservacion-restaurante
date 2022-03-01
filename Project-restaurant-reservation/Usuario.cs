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
    public partial class Usuario : Form
    {
        SqlConnection con = new SqlConnection("Data Source = LAPTOPALEX; Initial Catalog = restaurante; Integrated Security = True");
        public Usuario()
        {
            InitializeComponent();
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            dtg_usuarios.DataSource = listaU();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_cedula.Text) || string.IsNullOrEmpty(txt_correo.Text) || string.IsNullOrEmpty(txt_dire.Text) || string.IsNullOrEmpty(txt_nick.Text) || string.IsNullOrEmpty(txt_nombre.Text) || string.IsNullOrEmpty(txt_pass.Text) || string.IsNullOrEmpty(txt_telf.Text))
            {
                MessageBox.Show("No debe haber campos vacios !!");
            }
            else
            {
                registrar(txt_nombre.Text, txt_cedula.Text, txt_nick.Text, txt_pass.Text, txt_dire.Text, txt_correo.Text, txt_telf.Text);
                limpiar();
                MessageBox.Show("Usuario registrado !!");
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            try
            {
                string actu = "UPDATE tbl_usuario SET usu_nombre=@usu_nombre, usu_cedula=@usu_cedula, usu_nomlogin=@usu_nomlogin,usu_password=@usu_password,usu_direccion=@usu_direccion,usu_correo=@usu_correo,usu_telefono=@usu_telefono WHERE usu_id =@usu_id";
                SqlCommand cmd3 = new SqlCommand(actu, con);

                int id = Convert.ToInt32(dtg_usuarios.CurrentRow.Cells["usu_id"].Value.ToString());
                cmd3.Parameters.AddWithValue("usu_id", id);
                cmd3.Parameters.AddWithValue("usu_nombre", txt_nombre.Text);
                cmd3.Parameters.AddWithValue("usu_cedula", txt_cedula.Text);
                cmd3.Parameters.AddWithValue("usu_nomlogin", txt_nick.Text);
                cmd3.Parameters.AddWithValue("usu_password", txt_pass.Text);
                cmd3.Parameters.AddWithValue("usu_direccion", txt_dire.Text);
                cmd3.Parameters.AddWithValue("usu_correo", txt_correo.Text);
                cmd3.Parameters.AddWithValue("usu_telefono", txt_telf.Text);
                cmd3.ExecuteNonQuery();
                MessageBox.Show("Datos actualizados");
                con.Close();
                dtg_usuarios.DataSource = listaU();
                btn_guardar.Enabled = true;
            }
            catch (Exception)
            {

                
            } 

        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            //if (dtg_usuarios.SelectedRows.Count > 0)
            //{
            try
            {
                int id = Convert.ToInt32(dtg_usuarios.CurrentRow.Cells["usu_id"].Value.ToString());
                string del = "DELETE FROM tbl_usuario WHERE usu_id = @usu_id";
                SqlCommand cmd2 = new SqlCommand(del, con);
                cmd2.Parameters.AddWithValue("usu_id", id);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Datos Eliminados");
                dtg_usuarios.DataSource = listaU();
            }
            catch (Exception)
            {

               
            }
            
        }

        private void limpiar()
        {
            txt_cedula.Text = txt_correo.Text = txt_dire.Text = txt_nick.Text = txt_nombre.Text = txt_pass.Text = txt_telf.Text = "";

        }
        public DataTable listaU()
        {
                    
                con.Open();
                //SqlCommand cmd1 = new SqlCommand("SELECT * FROM tbl_platos", con);
                DataTable dt = new DataTable();
                string consu = "SELECT* FROM tbl_usuario";
                SqlCommand cmd1 = new SqlCommand(consu, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                da.Fill(dt);
                return dt;
        }

        private void dtg_usuarios_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtg_usuarios.SelectedRows.Count > 0)
            {
                if (dtg_usuarios.CurrentRow.Cells["usu_id"].Value.ToString() == "0")
                {
                    MessageBox.Show("No hay datos...");
                }
                else
                {
                    
                    txt_nombre.Text = dtg_usuarios.CurrentRow.Cells["usu_nombre"].Value.ToString();
                    txt_cedula.Text = dtg_usuarios.CurrentRow.Cells["usu_cedula"].Value.ToString();
                    txt_correo.Text = dtg_usuarios.CurrentRow.Cells["usu_correo"].Value.ToString();
                    txt_dire.Text = dtg_usuarios.CurrentRow.Cells["usu_direccion"].Value.ToString();
                    txt_nick.Text = dtg_usuarios.CurrentRow.Cells["usu_nomlogin"].Value.ToString();
                    txt_pass.Text = dtg_usuarios.CurrentRow.Cells["usu_password"].Value.ToString();
                    txt_telf.Text = dtg_usuarios.CurrentRow.Cells["usu_telefono"].Value.ToString();
                    btn_guardar.Enabled = false;
                }
            }
            else
            {

                MessageBox.Show("Seleccione una fila");
            }
        }

        private void registrar(string nom, string cedula, string nick, string pass, string direccion, string correo, string telefono)
        {
            try
            {
                //con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_usuario (usu_nombre,usu_cedula,usu_nomlogin,usu_password,usu_direccion,usu_correo,usu_estado,usu_telefono,tusu_id) " +
                    "VALUES(@nomb,@ced,@nick,@pass,@dire,@correo,@estado,@telf,@rol)", con);
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
                con.Close();
                dtg_usuarios.DataSource = listaU();

            }
            catch (Exception ex)
            {

            }


        }
    }
}
