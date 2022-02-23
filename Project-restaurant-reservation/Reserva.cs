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
    public partial class Reserva : Form
    {
        SqlConnection con = new SqlConnection("Data Source = LAPTOPALEX; Initial Catalog = restaurante; Integrated Security = True");
        public Reserva()
        {
            InitializeComponent();
        }

        private void limpiar()
        {
            txt_comensal.Text = txt_mesa.Text = txt_tservicio.Text = txt_usuario.Text = "";

        }
        public DataTable listaR()
        {

            con.Open();
            DataTable dt = new DataTable();
            string consu = "SELECT* FROM tbl_reserva";
            SqlCommand cmd1 = new SqlCommand(consu, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(dt);
            return dt;
        }
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_comensal.Text) || string.IsNullOrEmpty(txt_mesa.Text) || string.IsNullOrEmpty(txt_tservicio.Text) || string.IsNullOrEmpty(txt_usuario.Text) || string.IsNullOrEmpty(calendar.Text))
            {
                MessageBox.Show("No debe haber campos vacios !!");
            }
            else
            {
                //Cambiar en el tipo de dato de enviio a texto cuando se incluya el comboBox
                //por ahora solo manda enteros TANTO EN EL GUARDAR COMO ACTUALIZAR
                registrar(Convert.ToInt32(txt_mesa.Text), Convert.ToInt32(txt_comensal.Text),Convert.ToDateTime(calendar.Text), Convert.ToInt32(txt_tservicio.Text), Convert.ToInt32(txt_usuario.Text));
                limpiar();
                MessageBox.Show("Reservacion de mesa registrada !!");
            }

        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            try
            {
                string actu = "UPDATE tbl_reserva SET res_numesa=@numesa, res_numComensales=@numComen,res_fecha=@fecha,tise_id=@tserv ,us_id=@usu_id WHERE res_id =@res_id";
                SqlCommand cmd3 = new SqlCommand(actu, con);

                int id = Convert.ToInt32(dtg_reservas.CurrentRow.Cells["res_id"].Value.ToString());
                cmd3.Parameters.AddWithValue("res_id", id);
                cmd3.Parameters.AddWithValue("numesa", txt_mesa);
                cmd3.Parameters.AddWithValue("numComen", txt_comensal);
                cmd3.Parameters.AddWithValue("fecha", calendar);
                cmd3.Parameters.AddWithValue("tserv", txt_tservicio);
                cmd3.Parameters.AddWithValue("usu_id", txt_usuario);
                cmd3.ExecuteNonQuery();
                MessageBox.Show("Datos actualizados");
                con.Close();
                dtg_reservas.DataSource = listaR();
                btn_guardar.Enabled = true;
            }
            catch (Exception)
            {

                //ex.Message(PrintDialog);
            }


        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dtg_reservas.CurrentRow.Cells["res_id"].Value.ToString());
                string del = "DELETE FROM tbl_usuario WHERE res_id = @res_id";
                SqlCommand cmd2 = new SqlCommand(del, con);
                cmd2.Parameters.AddWithValue("res_id", id);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Datos Eliminados");
                dtg_reservas.DataSource = listaR();
            }
            catch (Exception)
            {


            }

        }

        private void Reserva_Load(object sender, EventArgs e)
        {
            dtg_reservas.DataSource = listaR();
        }

        private void dtg_reservas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtg_reservas.SelectedRows.Count > 0)
            {
                if (dtg_reservas.CurrentRow.Cells["res_id"].Value.ToString() == "0")
                {
                    MessageBox.Show("No hay datos...");
                }
                else
                {
                    txt_mesa.Text = dtg_reservas.CurrentRow.Cells["res_numesa"].Value.ToString();
                    txt_comensal.Text = dtg_reservas.CurrentRow.Cells["res_numComensales"].Value.ToString();
                    txt_tservicio.Text = dtg_reservas.CurrentRow.Cells["tise_id"].Value.ToString();
                    txt_usuario.Text = dtg_reservas.CurrentRow.Cells["usu_id"].Value.ToString();
                    calendar.Text = dtg_reservas.CurrentRow.Cells["res_fecha"].Value.ToString();
                   
                    btn_guardar.Enabled = false;
                }
            }
            else
            {

                MessageBox.Show("Seleccione una fila");
            }


        }
        private void registrar(int numesa , int numComen, DateTime fecha, int tserv, int usu_id)
        {
            try
            {
                //con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_reserva (res_numesa,res_numComensales,res_fecha,tise_id,usu_id) VALUES(@numesa,@numComen,@fecha,@tserv,@usu_id)", con);
                cmd.Parameters.AddWithValue("numesa",Convert.ToInt32( numesa));
                cmd.Parameters.AddWithValue("numComen", Convert.ToInt32(numComen));
                cmd.Parameters.AddWithValue("fecha",fecha);
                cmd.Parameters.AddWithValue("tserv", Convert.ToInt32(tserv));
                cmd.Parameters.AddWithValue("usu_id",Convert.ToInt32( usu_id));
                cmd.ExecuteNonQuery();
                con.Close();
                dtg_reservas.DataSource = listaR();

            }
            catch (Exception ex)
            {

            }


        }
    }
}
