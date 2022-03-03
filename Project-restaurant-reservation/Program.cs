using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_restaurant_reservation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
            //Application.Run(new Registro_platos());
            //Application.Run(new Registro_usuarios());
            //Application.Run(new HistoriaCliente());
            //Application.Run(new plantilla_Admin()); por revisar aun
            //Application.Run(new Reserva());
            //Application.Run(new PlantUsuarios());
        }
    }
}
