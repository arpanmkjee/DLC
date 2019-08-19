using System;
using System.Collections.Generic;
using System.Text;

namespace SmartEssentials.Entities.Core.Core
{
    public class WebServiceConfig
    {

        public Int32 WebServiceConfigID { get; set; }

        public Guid TenantID { get; set; }

        public String URL { get; set; }

        public String RequestType { get; set; }

        public String SampleRequest { get; set; }

        public String ResponseConfigJSON { get; set; }

    }

}
