using Microsoft.Extensions.Options;
using SmartEssentials.Entities.Contracts;
using SmartEssentials.Entities.Core;
using SmartEssentials.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartEssentials.Repositories
{
    public class ModuleRepository : FullBaseRepository<Module>, IModuleRepository
    {
        public ModuleRepository(IOptions<AppSettings> appSettings,
                              IClientContext clientContext) : base(appSettings, clientContext)
        {
            _appSettings = appSettings.Value;
            _clientContext = clientContext;
        }
    }
}
