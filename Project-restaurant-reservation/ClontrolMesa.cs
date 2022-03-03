using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_restaurant_reservation
{
    public class ClontrolMesa
    {
        SqlConnection con = new SqlConnection("Data Source = LAPTOPALEX; Initial Catalog = restaurante; Integrated Security = True");

        public string[] seleccionarStatusMesa()
        {
            string[] arraymesas = new string[12];

            con.Open();
            SqlCommand Comando = new SqlCommand();
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = "SELECT* FROM tbl_mesa";

            mesa _municipio = new mesa();


            try
            {
                int i = 0;
                IDataReader lector = Comando.ExecuteReader();
                while (lector.Read())
                {

                    mesa _municipi = new mesa();

                    arraymesas[i] = lector[2].ToString();

                    i++;

                }

                arraymesas[i + 1] = "fin";
            }
            catch (Exception ex)
            {
                string m = ex.Message;
                Comando.Dispose();
            }

            finally
            {
                con.Close();
            }

            return arraymesas;
        }

    }
}
