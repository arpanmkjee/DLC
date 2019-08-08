using System;

namespace SmartEssentials.Models
{
    public class UserRole
    {

        public Guid UserRoleID { get; set; }

        public Guid RoleID { get; set; }

        public Guid UserID { get; set; }

        public bool Active { get; set; }

    }
}
