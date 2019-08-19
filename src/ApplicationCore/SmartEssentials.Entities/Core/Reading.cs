using System;

namespace SmartEssentials.Entities.Core
{
    public class Reading
    {
        public Guid ReadingID { get; set; }

        public Guid RequestID { get; set; }

        public Guid TenantID { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public String ResultsJSON { get; set; }

    }
}
