using SmartEssentials.Entities.Core;
using System;

namespace SmartEssentials.Entities.Contracts
{
    public class ClientContext : IClientContext
    {
        public ClientContext()
        {

        }
        public User User { get; set; }
        public Guid TenantID { get { return User.TenantID; } }
        public string AccessToken { get; set; }

    }
}
