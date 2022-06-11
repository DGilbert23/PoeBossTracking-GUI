using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeBossTracking.Classes
{
    internal class GlobalVariables
    {
        private static string username;
        public static string Username { get { return username; } set { username = value; } }
    }
}
