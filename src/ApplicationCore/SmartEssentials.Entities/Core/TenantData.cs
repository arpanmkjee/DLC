using System;
using System.Collections.Generic;
using System.Text;

namespace SmartEssentials.Entities.Core
{
    public class TenantData
    {

        public Guid TenantDataID { get; set; }

        public Guid TenantID { get; set; }

        public string JsonData { get; set; }

    }
}
