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
    public partial class tipoplato : Form
    {
        SqlConnection con = new SqlConnection("Data Source = LAPTOPALEX; Initial Catalog = restaurante; Integrated Security = True");
        public tipoplato()
        {
            InitializeComponent();
        }

        private void tipoplato_Load(object sender, EventArgs e)
        {

            dtg_tipop.DataSource = listaP();
        }

        public DataTable listaP()
        {

            con.Open();
            DataTable dt = new DataTable();
            string consu = "SELECT* FROM tbl_tipoplato";
            SqlCommand cmd1 = new SqlCommand(consu, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(dt);
            return dt;
            
        }
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_tipop.Text))
            {
                MessageBox.Show("No debe haber campos vacios !!");
            }
            else
            {
                registrar(txt_tipop.Text);
                limpiar();
                MessageBox.Show("Usuario registrado !!");
            }

        }

        private void limpiar()
        {
            txt_tipop.Text = "";

        }
        private void btn_editar_Click(object sender, EventArgs e)
        {
            try
            {
                string actu = "UPDATE tbl_tipoplato SET tipl_nombre=@tipl_nombre WHERE tipl_id =@tipl_id";
                SqlCommand cmd3 = new SqlCommand(actu, con);

                int id = Convert.ToInt32(dtg_tipop.CurrentRow.Cells["tipl_id"].Value.ToString());
                cmd3.Parameters.AddWithValue("tipl_id", id);
                cmd3.Parameters.AddWithValue("tipl_nombre", txt_tipop.Text);
               
                cmd3.ExecuteNonQuery();
                MessageBox.Show("Datos actualizados");
                con.Close();
                dtg_tipop.DataSource = listaP();
                btn_guardar.Enabled = true;
                limpiar();
            }
            catch (Exception)
            {


            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                
                int id = Convert.ToInt32(dtg_tipop.CurrentRow.Cells["tipl_id"].Value.ToString());
                string del = "DELETE FROM tbl_tipoplato WHERE tipl_id = @tipl_id";
                SqlCommand cmd2 = new SqlCommand(del, con);
                cmd2.Parameters.AddWithValue("tipl_id", id);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Datos Eliminados");
                con.Close();
                dtg_tipop.DataSource = listaP();
                btn_guardar.Enabled = true;
                limpiar();
                
            }
            catch (Exception)
            {


            }
        }

        private void dtg_tipop_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtg_tipop.SelectedRows.Count > 0)
            {
                if (dtg_tipop.CurrentRow.Cells["tipl_id"].Value.ToString() == "0")
                {
                    MessageBox.Show("No hay datos...");
                }
                else
                {

                    txt_tipop.Text = dtg_tipop.CurrentRow.Cells["tipl_nombre"].Value.ToString();

                    btn_guardar.Enabled = false;
                }
            }
            else
            {

                MessageBox.Show("Seleccione una fila");
            }
        }

        private void registrar(string nom)
        {
            try
            {
                
                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_tipoplato (tipl_nombre) VALUES(@tipl_nombre)", con);
                cmd.Parameters.AddWithValue("tipl_nombre", nom);
                cmd.ExecuteNonQuery();
                con.Close();
                dtg_tipop.DataSource = listaP();

            }
            catch (Exception ex)
            {

            }
        }
    }
}
