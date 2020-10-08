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
    public class GiroController : ControllerBase
    {
        private IGiroRepository repository;

        public GiroController(IGiroRepository repo)
        {
            repository = repo;
        }
        // GET: api/Giro
        [HttpGet]
        public IEnumerable<Giros> Get()
        {
            return repository.Giros;
        }

        // GET: api/Giro/5
        [HttpGet("{id}")]
        public Giros Get(int id)
        {
            return repository.Get(id);
        }

        // POST: api/Giro
        [HttpPost]
        public void Post([FromBody] Giros acc)
        {
            repository.Add(acc);
        }

        // PUT: api/Giro/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Giros new_acc)
        {
            repository.Put(id,new_acc);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
