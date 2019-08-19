using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartEssentials.Entities.Core
{
    public class User
    {

        public Guid UserID { get; set; }

        public Guid TenantID { get; set; }

        [MaxLength(50)]
        public String FirstName { get; set; }

        [MaxLength(50)]
        public String LastName { get; set; }

        [MaxLength(50)]
        public String Email { get; set; }


        [MaxLength(50)]
        public String UserName { get; set; }


        public Int32 AuthType { get; set; }

        [MaxLength(100)]
        public String Password { get; set; }

        [MaxLength(500)]
        public String AccessToken { get; set; }

        [MaxLength(500)]
        public String RefreshToken { get; set; }

        public DateTime TokenLastUpdateTime { get; set; }

        public DateTime LastLoginTime { get; set; }

        [MaxLength(50)]
        public String PasswordResetCode { get; set; }

        public DateTime PasswordResetCodeTime { get; set; }

        public String SettingsJSON { get; set; }

        public Boolean Active { get; set; }

        public Boolean IsTenantAdmin { get; set; }

    }
}
