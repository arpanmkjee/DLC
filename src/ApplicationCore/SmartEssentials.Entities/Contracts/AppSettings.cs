using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartEssentials.Entities.Contracts
{
    public class AppSettings : IAppSettings
    {
        public string ConnectionString { get; set; }
    }
}
