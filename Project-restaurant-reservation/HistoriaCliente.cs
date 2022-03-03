using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Cache;

namespace Project_restaurant_reservation
{
    public partial class HistoriaCliente : Form
    {
        SqlConnection con = new SqlConnection("Data Source = LAPTOPALEX; Initial Catalog = restaurante; Integrated Security = True");
        public HistoriaCliente()
        {
            InitializeComponent();
        }

        private void HistoriaCliente_Load(object sender, EventArgs e)
        {

            datos();
        }

        private void datos()
        {
            
            var id = UserLoginCache.idUsuario;

            con.Open();
            DataTable dt = new DataTable();
            string consu = "SELECT* FROM tbl_reserva where usu_id = "+ id;
            SqlCommand cmd = new SqlCommand(consu, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dgv_historial.DataSource = dt;

        }

        private void traerQr()
        {
            var qr = dgv_historial.CurrentRow.Cells["res_id"].Value.ToString();
            SqlConnection con = new SqlConnection("Data Source = LAPTOPALEX; Initial Catalog = restaurante; Integrated Security = True");
            SqlCommand cmd = new SqlCommand("select res_qr from tbl_reserva where res_id ="+ qr, con);
            SqlDataAdapter dt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet("tbl_reserva");

            byte[] imagen = new byte[0];

            dt.Fill(ds, "tbl_reserva");
            DataRow dr = ds.Tables["tbl_reserva"].Rows[0];
            imagen = (byte[])dr["res_qr"];
            MemoryStream ms = new MemoryStream(imagen);
            pictureBox1.Image = Image.FromStream(ms);
        }

        private void dgv_historial_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgv_historial.SelectedRows.Count > 0)
            {
                if (dgv_historial.CurrentRow.Cells["res_id"].Value.ToString() == "0")
                {
                    MessageBox.Show("No hay datos...");
                }
                else
                {
                    traerQr();

                    //var id = dgv_historial.CurrentRow.Cells["res_id"].Value.ToString();

                }
            }
            else
            {

                MessageBox.Show("Seleccione una fila");
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
