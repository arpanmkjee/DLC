using System;
using System.ComponentModel.DataAnnotations;

namespace SmartEssentials.Entities.Core
{
    public class ErrorLog
    {
        public String ErrorLogID { get; set; }

        [MaxLength(50)]
        public String Location { get; set; }

        public String LogData { get; set; }

        public DateTime Timestamp { get; set; }

    }




}
