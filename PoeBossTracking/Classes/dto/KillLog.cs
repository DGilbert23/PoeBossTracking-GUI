using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeBossTracking.Classes.dto
{
    internal class KillLog
    {
        public string loggedKillId { get; set; }
        public string bossId { get; set; }
        public List<KillDrop> drops { get; set; }

        public KillLog(string loggedKillId, string bossId, List<KillDrop> drops)
        {
            this.loggedKillId = loggedKillId;
            this.bossId = bossId;
            this.drops = drops;
        }
    }
}
