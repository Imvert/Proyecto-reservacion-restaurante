using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_restaurant_reservation
{
     public class mesa
    {
        private int id;
        private int numeroMesa;
        private char status;


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int NumeroMesa
        {
            get { return numeroMesa; }
            set { numeroMesa = value; }
        }
        public char Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
