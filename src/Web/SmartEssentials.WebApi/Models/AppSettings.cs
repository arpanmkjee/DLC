﻿using SmartEssentials.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartEssentials.WebApi.Models
{
    public class AppSettings : IAppSettings
    {
        public string ConnectionString { get; set; }
    }
}
