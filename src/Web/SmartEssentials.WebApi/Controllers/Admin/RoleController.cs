using System;
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
    public class RoleController : FullBaseController<IRoleRepository, Role>
    {
        public RoleController(IRoleRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
