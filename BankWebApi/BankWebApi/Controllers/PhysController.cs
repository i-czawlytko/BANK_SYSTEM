using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankWebApi.Entitys;
using BankWebApi.ContextFolder;
using BankWebApi.Reposes;

namespace BankWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhysController : ControllerBase
    {
        private IPhysRepository repository;

        public PhysController(IPhysRepository repo)
        {
            repository = repo;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<PhysClients> Get()
        {
            return repository.Physes;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public PhysClients Get(int id)
        {
            return repository.Get(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] PhysClients client)
        {
            repository.Add(client);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
