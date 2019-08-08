using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartEssentials.Models
{
    public class Role
    {

        public Guid RoleID { get; set; }

        public Guid TenantID { get; set; }

        [MaxLength(50)]
        public String RoleName { get; set; }

        public String SettingsJSON { get; set; }

        public Boolean Active { get; set; }

    }


}
