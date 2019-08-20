﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartEssentials.Entities.Core;
using SmartEssentials.Repositories;
using SmartEssentials.WebApi.Controllers.Base;

namespace SmartEssentials.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : FullBaseController<ITenantRepository, Tenant>
    {
        public TenantController(ITenantRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
