using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartEssentials.Entities.Core;
using SmartEssentials.Repositories;
using SmartEssentials.WebApi.Controllers.Base;
using SmartEssentials.WebApi.Filters;

namespace SmartEssentials.WebApi.Controllers
{
    [Authorize]
    [ServiceFilter(typeof(EnsureUserLoggedIn))]
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : FullBaseController<IModuleRepository, Module>
    {
        public ModuleController(IModuleRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
