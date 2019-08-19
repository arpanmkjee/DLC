using System;
using System.Collections.Generic;
using System.Text;

namespace SmartEssentials.Entities.Core
{
    public class Ping
    {
        public Guid PingID { get; set; }

        public Guid RequestID { get; set; }

        public Guid TenantID { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string ResultsJSON { get; set; }

    }
}
