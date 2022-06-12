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
        private const string apiURL = "http://localhost:8080/";
        public static string ApiUrl { get { return apiURL; } }
    }
}
