using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartEssentials.Models
{
    public class Module
    {
        public Guid ModuleID { get; set; }

        [MaxLength(50)]
        public String ModuleName { get; set; }

        public String ModuleDataJSON { get; set; }

        public Boolean Active { get; set; }

    }
}
