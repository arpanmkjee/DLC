using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartEssentials.Entities.Core
{
    public class AppConfig
    {
        public Guid AppConfigID { get; set; }

        [MaxLength(50)]
        public String ConfigType { get; set; }

        [MaxLength(100)]
        public String ConfigValue { get; set; }

        public Boolean Active { get; set; }

    }
}
