using System;
using System.Collections.Generic;
using System.Text;

namespace SmartEssentials.Models
{
    public class Voltage
    {

        public Guid VoltageID { get; set; }


        public Guid RequestID { get; set; }


        public Guid TenantID { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public String ResultsJSON { get; set; }

    }
}
