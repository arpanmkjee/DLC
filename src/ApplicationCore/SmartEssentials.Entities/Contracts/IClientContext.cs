using SmartEssentials.Entities.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartEssentials.Entities.Contracts
{
    public interface IClientContext
    {
        User User { get; set; }
        Guid TenantID { get; }
        string AccessToken { get; set; }
    }
}
