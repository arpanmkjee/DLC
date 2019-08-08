using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartEssentials.Models
{
    public class Request
    {
        public Guid RequestID { get; set; }

        public Guid RequestUserID { get; set; }

        public Guid TenantID { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        [MaxLength(50)]
        public String RequestESN { get; set; }

        public String DataJSON { get; set; }

    }
}
