using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeBossTracking.Classes.dto
{
    internal class LoggedKill
    {
        public string loggedKillId { get; set; }
        public string bossId { get; set; }
        public string appUserId { get; set; }
        public DateTime killDate { get; set; }

        public LoggedKill(string loggedKillId, string bossId, string appUserId, DateTime killDate)
        {
            this.loggedKillId = loggedKillId;
            this.bossId = bossId;
            this.appUserId = appUserId;
            this.killDate = killDate;
        }
    }
}
