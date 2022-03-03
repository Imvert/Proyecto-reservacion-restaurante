using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Cache;
using ZXing;
using ZXing.QrCode;
using System.Drawing.Imaging;
using System.IO;

namespace Project_restaurant_reservation
{
    public partial class Reserva_mesa : Form
    {
        SqlConnection con = new SqlConnection("Data Source = LAPTOPALEX; Initial Catalog = restaurante; Integrated Security = True");
        private void Reserva_mesa_Load(object sender, EventArgs e)
        {

           // dtg_platos.DataSource = listaU();//trae toda la informacion
            cmb_servicio.DataSource = CargarComboServicio();
            cmb_servicio.DisplayMember = "tise_nombre";
            cmb_servicio.ValueMember = "tise_id";
            //cmb de las mesas 
            cmb_nuMesa.DataSource = CmbMesas();
            cmb_nuMesa.DisplayMember = "mesa_num";
            cmb_nuMesa.ValueMember = "mesa_id";
            traerDatos();
            pintar();
            
        }
        public Reserva_mesa()
        {
            InitializeComponent();
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public DataTable CargarComboServicio()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT tise_id,tise_nombre FROM tbl_tiposervicio", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                sda.Fill(dt1);
                return dt1;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public DataTable CmbMesas()
        {
            try
            {
             
                SqlCommand cmd = new SqlCommand("SELECT mesa_id,mesa_num FROM tbl_mesa", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt2 = new DataTable();
                sda.Fill(dt2);
                return dt2;
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void btn_Reservar_Click(object sender, EventArgs e)
        {
            var id = txt_id.Text = Convert.ToString(UserLoginCache.idUsuario);

            if (string.IsNullOrEmpty(cmb_nuMesa.Text) || string.IsNullOrEmpty(cmb_servicio.Text))
            {
                MessageBox.Show("Porfavor, selecione mesa y/o servicio !!");
            }
            else
            {
                try
                {
                    //CREACION DEL CODIGO QR
                    var opciones = new QrCodeEncodingOptions
                    {
                        Height = pictureBox1.Height,
                        Width = pictureBox1.Width
                    };

                    //CREAR INSTANCIA DE BARCODEWRITTER
                    var writer = new BarcodeWriter();

                    writer.Format = BarcodeFormat.QR_CODE;
                    writer.Options = opciones;
                    var text = $"BEGIN:VCARD" +
                        $"VERSION:3.0\n" +
                        $"N: {txt_cliente.Text}  <- Nombre Cliente\n" +
                        $"TEL: {cmb_nuMesa.Text} <-Numero de mesa\n" +//telefono despues de nombre
                        $"ADR:  {dtp_fecha.Value} <-Fecha reservacion\n" +//este va despues de telefono
                        $"NOTE: {N_comensales.Value} <-Numero de comensales\n" +//note aparece de los ultimos
                        $"END:VCARD";
                    var rs = writer.Write(text);
                    //aqui iva la impresion del codigo qr

                    MemoryStream archivoM = new MemoryStream();
                    rs.Save(archivoM, ImageFormat.Bmp);

                    SqlCommand cmd = new SqlCommand("INSERT INTO tbl_reserva (usu_id,res_numesa,res_numComensales,res_fecha,tise_id,mesa_id,res_qr) VALUES(@id,2,@comen,@fecha,@serv,@mesa,@img)", con);
                    cmd.Parameters.AddWithValue("id", Convert.ToInt32( id));
                    cmd.Parameters.AddWithValue("comen", Convert.ToInt32(N_comensales.Value));
                    cmd.Parameters.AddWithValue("fecha", Convert.ToDateTime(dtp_fecha.Text));
                    cmd.Parameters.AddWithValue("serv", Convert.ToInt32(cmb_servicio.SelectedValue.ToString()));
                    cmd.Parameters.AddWithValue("mesa", Convert.ToInt32(cmb_nuMesa.SelectedValue.ToString()));
                    cmd.Parameters.AddWithValue("img", archivoM.GetBuffer());
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("RESERVA REALIZADA....");
                    pictureBox1.Image = rs;
                    limpiar();
                    btn_Reservar.Enabled = false;
                }
                catch (SqlException ex)
                {
                    StringBuilder errorMessages = new StringBuilder();
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + ex.Errors[i].Message + "\n" +
                            "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                            "Source: " + ex.Errors[i].Source + "\n" +
                            "Procedure: " + ex.Errors[i].Procedure + "\n");
                    }
                    Console.WriteLine(errorMessages.ToString());
                }
               
            }
        }

        public void CodigoQr()
        {
            var opciones = new QrCodeEncodingOptions
            {
                Height = pictureBox1.Height,
                Width = pictureBox1.Width
            };

            //CREAR INSTANCIA DE BARCODEWRITTER
            var writer = new BarcodeWriter();

            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = opciones;
            var text = $"BEGIN:VCARD" +
                $"VERSION:3.0\n" +
                $"N: {txt_cliente.Text}  <- Nombre Cliente\n" +
                $"TEL: {cmb_nuMesa.Text} <-Numero de mesa\n" +//telefono despues de nombre
                $"ADR:  {dtp_fecha.Value} <-Fecha reservacion\n" +//este va despues de telefono
                $"NOTE: {N_comensales.Value} <-Numero de comensales\n" +//note aparece de los ultimos
                $"END:VCARD";
            var rs = writer.Write(text);
            pictureBox1.Image = rs;

        }

        public void traerDatos()//trae datos del cache
        {
            txt_cliente.Text = UserLoginCache.name;
            txt_id.Text = Convert.ToString(UserLoginCache.idUsuario);
        
        }

        public void pintar()
        {
            mes_10.BackColor = Color.Lime;

        }

        public void limpiar()
        {
            cmb_servicio.ValueMember = "";
            cmb_nuMesa.ValueMember = "";
            N_comensales.ResetText();
        
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}
