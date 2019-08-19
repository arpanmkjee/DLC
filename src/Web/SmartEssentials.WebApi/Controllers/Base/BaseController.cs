using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartEssentials.Repositories.Base;
using SmartEssentials.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartEssentials.WebApi.Controllers.Base
{
    public class FullBaseController<Repo,T> : ControllerBase
            where T:new()
            where Repo:IFullBaseRepository<T>,new()
    {
        private Repo _repository { get; set; }
        private readonly AppSettings _mySettings;
        private string _tenantId { get; set; }

        public FullBaseController(IOptions<AppSettings> settings)
        {
            _mySettings = settings.Value;
            _repository = new Repo();
        }
    }
}
