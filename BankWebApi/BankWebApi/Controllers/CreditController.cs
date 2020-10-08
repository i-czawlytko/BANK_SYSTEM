using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankWebApi.Entitys;
using BankWebApi.ContextFolder;
using BankWebApi.Reposes;

namespace BankWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditController : ControllerBase
    {
        private ICreditRepository repository;

        public CreditController(ICreditRepository repo)
        {
            repository = repo;
        }
        // GET: api/Credit
        [HttpGet]
        public IEnumerable<Credits> Get()
        {
            return repository.Credits;
        }

        // GET: api/Credit/5
        [HttpGet("{id}")]
        public Credits Get(int id)
        {
            return repository.Get(id);
        }

        // POST: api/Credit
        [HttpPost]
        public void Post([FromBody] Credits acc)
        {
            repository.Add(acc);
        }

        // PUT: api/Credit/5
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
