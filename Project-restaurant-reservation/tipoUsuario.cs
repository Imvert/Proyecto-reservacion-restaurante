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
    public partial class tipoUsuario : Form
    {
        SqlConnection con = new SqlConnection("Data Source = LAPTOPALEX; Initial Catalog = restaurante; Integrated Security = True");
        public tipoUsuario()
        {
            InitializeComponent();
        }

        private void tipoUsuario_Load(object sender, EventArgs e)
        {

        }

        private void limpiar()
        {
            txt_rol.Text = txt_Estado.Text = "";

        }
        public DataTable listatP()
        {

            con.Open();
            DataTable dt = new DataTable();
            string consu = "SELECT* FROM tbl_tipousuario";
            SqlCommand cmd1 = new SqlCommand(consu, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(dt);
            return dt;
        }
        private void dgt_rol_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgt_rol.SelectedRows.Count > 0)
            {
                if (dgt_rol.CurrentRow.Cells["tusu_id"].Value.ToString() == "0")
                {
                    MessageBox.Show("No hay datos...");
                }
                else
                {

                    txt_rol.Text = dgt_rol.CurrentRow.Cells["tusu_nombre"].Value.ToString();
                    txt_Estado.Text = dgt_rol.CurrentRow.Cells["tusu_estado"].Value.ToString();
                    
                    btn_guardar.Enabled = false;
                }
            }
            else
            {

                MessageBox.Show("Seleccione una fila");
            }

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_rol.Text) || string.IsNullOrEmpty(txt_Estado.Text))
            {
                MessageBox.Show("No debe haber campos vacios !!");
            }
            else
            {
                registrar(txt_rol.Text,txt_Estado.Text);
                limpiar();
                MessageBox.Show("Rol registrado !!");
            }

        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            try
            {
                string actu = "UPDATE tbl_tipousuario SET tusu_nombre=@tusu_nombre, tusu_estado=@tusu_estado WHERE tusu_id =@tusu_id";
                SqlCommand cmd3 = new SqlCommand(actu, con);

                int id = Convert.ToInt32(dgt_rol.CurrentRow.Cells["tusu_id"].Value.ToString());
                cmd3.Parameters.AddWithValue("tusu_id", id);
                cmd3.Parameters.AddWithValue("tusu_nombre", txt_rol);
                cmd3.Parameters.AddWithValue("tusu_estado", txt_Estado);
                cmd3.ExecuteNonQuery();
                MessageBox.Show("Datos actualizados");
                con.Close();
                dgt_rol.DataSource = listatP();
                btn_guardar.Enabled = true;
            }
            catch (Exception)
            {


            }

        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgt_rol.CurrentRow.Cells["tusu_id"].Value.ToString());
                string del = "DELETE FROM tbl_usuario WHERE tusu_id = @tusu_id";
                SqlCommand cmd2 = new SqlCommand(del, con);
                cmd2.Parameters.AddWithValue("tusu_id", id);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Datos Eliminados");
                dgt_rol.DataSource = listatP();
            }
            catch (Exception)
            {


            }
        }

        private void registrar(string nom,string estado)
        {
            try
            {
                //con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_tipousuario (tusu_nombre,tusu_estado) VALUES(@tusu_nombre,@tusu_estado)", con);
                cmd.Parameters.AddWithValue("tusu_nombre", nom);
                cmd.Parameters.AddWithValue("tusu_estado", estado);
                cmd.ExecuteNonQuery();
                con.Close();
                dgt_rol.DataSource = listatP();

            }
            catch (Exception ex)
            {

            }


        }
    }
}
