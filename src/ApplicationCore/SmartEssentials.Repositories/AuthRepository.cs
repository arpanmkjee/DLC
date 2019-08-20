﻿using Microsoft.Extensions.Options;
using SmartEssentials.Entities.Contracts;
using SmartEssentials.Entities.Core;
using SmartEssentials.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartEssentials.Repositories
{
    public class AuthRepository : BaseRepository<User>, IAuthRepository
    {
        public AuthRepository(IOptions<AppSettings> appSettings,
                              IClientContext clientContext) : base(appSettings,clientContext)
        {
            _appSettings = appSettings.Value;
            _clientContext = clientContext;
        }
}
}