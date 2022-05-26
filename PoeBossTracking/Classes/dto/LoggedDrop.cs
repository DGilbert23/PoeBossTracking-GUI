using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeBossTracking.Classes.dto
{
    internal class LoggedDrop
    {
        public string loggedDropId { get; set; }
        public string itemId { get; set; }
        public string loggedKillId { get; set; }
        public string itemValue { get; set; }

        public LoggedDrop(string newLoggedKillId, string newItemId, string newItemValue)
        {
            itemId = newItemId;
            loggedKillId = newLoggedKillId;
            itemValue = newItemValue;
        }
    }    
}
