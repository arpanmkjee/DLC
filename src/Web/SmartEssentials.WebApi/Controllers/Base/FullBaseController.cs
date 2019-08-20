using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartEssentials.Entities.Contracts;
using SmartEssentials.Repositories.Base;
using SmartEssentials.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartEssentials.WebApi.Controllers.Base
{
    public class FullBaseController<IRepository,T> : ControllerBase
            where T : new()
            where IRepository : IFullBaseRepository<T>
    {
        public IRepository _repository { get; set; }

        public FullBaseController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public ActionResult<DBTransactionResult<T>> Insert(T obj)
        {
            return _repository.Insert(obj);
        }

        [HttpPut]
        public ActionResult<DBTransactionResult<T>> Update(T obj)
        {
            return _repository.Update(obj);
        }

        [HttpGet]
        public ActionResult<T> Get(object primaryKeyValue)
        {
            return _repository.Get(primaryKeyValue);
        }

        [HttpDelete]
        public ActionResult<bool> Delete(object primaryKeyValue)
        {
            return _repository.Delete(primaryKeyValue);
        }

        [HttpPost]
        [Route("search")]
        public ActionResult<PagedResult<T>> Search(PagingRequest pagingRequest)
        {
            return _repository.GetAll(pagingRequest);
        }
    }
}
