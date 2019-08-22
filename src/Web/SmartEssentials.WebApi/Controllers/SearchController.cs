using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartEssentials.Repositories;
using System.Collections.Generic;

namespace SmartEssentials.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Route("Search")]
    //[EnableCors("_MySmitUiOrigins")]
    public class SearchController : ControllerBase
    {
        // GET: api/Search
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Search/5
        [HttpGet("{searchKey}", Name = "Get")]
        public JsonResult Get(string searchKey)
        {

            SearchRepository _searchRepository = new SearchRepository();

            return new JsonResult(_searchRepository.Search(searchKey))
            {
                StatusCode = StatusCodes.Status200OK
            };



        }

        // POST: api/Search
        [HttpPost]
        //[EnableCors("_MySmitUiOrigins")]
        public string Post([FromBody]dynamic value)
        {
            return "[{name: 'Tom Moody', address: '78160 Clyde Gallagher Street', meterNumber: 'O33942812'}" +
                "{ name: 'Tim Sloan', address: '9889 Charing Cross Alley', meterNumber: 'D02929934' }," +
                "{ name: 'Mike D', address: '7911 Killdeer Plaza', meterNumber: 'W47345229' }," +
                "{ name: 'Adam Gill', address: '10972 Morningstar Terrace', meterNumber: 'O01697761' }," +
                "{ name: 'Nugyen See', address: '3 Spaight Court', meterNumber: 'O84771039' }]";
        }

        // PUT: api/Search/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}


