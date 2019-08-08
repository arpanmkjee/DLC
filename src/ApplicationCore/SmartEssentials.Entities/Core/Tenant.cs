using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartEssentials.Models
{
    public class Tenant
    {
        public Guid TenantID { get; set; }

        [MaxLength(100)]
        public String TenantIdentifier { get; set; }

        [MaxLength(100)]
        public String TenantName { get; set; }

        public String SettingsJSON { get; set; }

        public Boolean Active { get; set; }

    }
}
