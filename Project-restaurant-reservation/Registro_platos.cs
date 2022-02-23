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
using System.IO;
using System.Drawing.Imaging;

namespace Project_restaurant_reservation
{
    public partial class Registro_platos : Form
    {
        SqlConnection con = new SqlConnection("Data Source = LAPTOPALEX; Initial Catalog = restaurante; Integrated Security = True");
        public Registro_platos()
        {
            InitializeComponent();
        }

        private void Registro_platos_Load(object sender, EventArgs e)
        {
            
            dtg_platos.DataSource = listaU();
            /*SqlCommand cmd = new SqlCommand("SELECT tipl_nombre FROM tbl_tipoplato", con);
            con.Open();
            SqlDataReader registro = cmd.ExecuteReader();
            while (registro.Read())
            {
                
                cmb_tplato.Items.Add(registro["tipl_nombre"].ToString());
            }
            con.Close();
            */
            cmb_tplato.DataSource = CargarCombo();
            cmb_tplato.DisplayMember = "tipl_nombre";
            cmb_tplato.ValueMember = "tipl_id";

        }

        public DataTable listaU()
        {
            
            con.Open();
            //SqlCommand cmd1 = new SqlCommand("SELECT * FROM tbl_platos", con);
            DataTable dt = new DataTable();
            string consu = "SELECT* FROM tbl_platos";
            SqlCommand cmd1 = new SqlCommand(consu,con);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(dt);
            return dt;
            
            
        }

        public DataTable CargarCombo()
        {
          // con.Open();
            SqlCommand cmd = new SqlCommand("SELECT tipl_id,tipl_nombre FROM tbl_tipoplato", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt1 = new DataTable();
            sda.Fill(dt1);
            return dt1;
           
            
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_platos (pla_nombre,pla_precio,pla_imagen,tipl_id) VALUES(@nom,@prec,@img,@plato)", con);
                MemoryStream archivoM = new MemoryStream();
                string rpt;
                //con.Open();

                pb_imagen.Image.Save(archivoM, ImageFormat.Bmp);

                cmd.Parameters.AddWithValue("nom", txt_nomP.Text);
                cmd.Parameters.AddWithValue("prec", Convert.ToDouble(txt_precio.Text));
                cmd.Parameters.AddWithValue("img", archivoM.GetBuffer());
                cmd.Parameters.AddWithValue("plato", Convert.ToInt32(cmb_tplato.SelectedValue.ToString()));
                rpt = cmd.ExecuteNonQuery() > 0 ? "Plato guardo con exito.." : "No se guardo el plato..";
                MessageBox.Show(rpt);
                dtg_platos.DataSource = listaU();
                //con.Close();
            }
            catch (Exception)
            {

            }
           
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            //con.Open(); //Eliminar funciona
            try
            {
                int id = Convert.ToInt32(dtg_platos.CurrentRow.Cells["pla_id"].Value.ToString());
                string del = "DELETE FROM tbl_platos WHERE pla_id = @pla_id";
                SqlCommand cmd4 = new SqlCommand(del, con);
                cmd4.Parameters.AddWithValue("pla_id", id);
                cmd4.ExecuteNonQuery();
                MessageBox.Show("Datos Eliminados");
                dtg_platos.DataSource = listaU();
                // con.Close();
            }
            catch (Exception)
            {

               
            }
             
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // con.Open();
                MemoryStream archivoM = new MemoryStream();
                // pb_imagen.Image.Save(archivoM, ImageFormat.Bmp);
                string actu = "UPDATE tbl_platos SET pla_nombre=@pla_nombre, pla_precio=@pla_precio, pla_imagen=@pla_imagen,tipl_id=@plato WHERE pla_id =@pla_id";
                SqlCommand cmd3 = new SqlCommand(actu, con);

                int id = Convert.ToInt32(dtg_platos.CurrentRow.Cells["pla_id"].Value.ToString());
                cmd3.Parameters.AddWithValue("pla_id", id);
                cmd3.Parameters.AddWithValue("pla_nombre", txt_nomP.Text);
                cmd3.Parameters.AddWithValue("pla_precio", Convert.ToDouble(txt_precio.Text));
                cmd3.Parameters.AddWithValue("pla_imagen", archivoM.GetBuffer());
                cmd3.Parameters.AddWithValue("plato", Convert.ToInt32(cmb_tplato.SelectedValue.ToString()));
                cmd3.ExecuteNonQuery();
                MessageBox.Show("Datos actualizados");
                dtg_platos.DataSource = listaU();
                //con.Close();
            }
            catch (Exception)
            {

                
            }
          
        }

        private void btn_imagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            DialogResult resultado = of.ShowDialog();

            if (resultado==DialogResult.OK)
            {
                pb_imagen.Image = Image.FromFile(of.FileName);
                pb_imagen.SizeMode = PictureBoxSizeMode.StretchImage;

            }
        }

        private void dtg_platos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (dtg_platos.SelectedRows.Count > 0)
            {
                if (dtg_platos.CurrentRow.Cells["pla_id"].Value.ToString() == "0")
                {
                    MessageBox.Show("No hay datos...");
                }
                else
                {
                    //editar = true;
                    txt_nomP.Text = dtg_platos.CurrentRow.Cells["pla_nombre"].Value.ToString();
                    txt_precio.Text = dtg_platos.CurrentRow.Cells["pla_precio"].Value.ToString();
                    pb_imagen.Text = dtg_platos.CurrentRow.Cells["pla_imagen"].Value.ToString();
                    btn_guardar.Enabled = false;
                }
            }
            else
            {

                MessageBox.Show("Seleccione una fila");
            }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Usuario usu = new Usuario();
            //usu.MdiParent = this;
            //usu.Text = "Form - " + this.MdiChildren.Length.ToString();
            //usu.Show();
        }

    }
}
