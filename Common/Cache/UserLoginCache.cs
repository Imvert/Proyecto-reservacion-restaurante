using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache
{
     public static class UserLoginCache
    {
        public static int idUsuario { get; set; }
        public static string name { get; set; }
        public static string cedula { get; set; }
        public static string correo { get; set; }
        public static int rolUsuario { get; set; }
    }
}
