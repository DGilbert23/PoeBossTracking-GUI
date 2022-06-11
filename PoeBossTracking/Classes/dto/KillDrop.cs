using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeBossTracking.Classes.dto
{
    internal class KillDrop
    {
        public string itemId { get; set; }
        public string itemValue { get; set; }
        public int count { get; set; }

        public KillDrop(string itemId, string itemValue, int count)
        {
            this.itemId = itemId;
            this.itemValue = itemValue;
            this.count = count;
        }
    }
}
