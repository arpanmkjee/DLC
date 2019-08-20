using System;
using System.Collections.Generic;
using System.Text;

namespace SmartEssentials.Entities.Contracts
{
    public interface IAppSettings
    {
        string ConnectionString { get; set; }
    }
}
