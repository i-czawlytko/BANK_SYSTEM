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
    public class DepositController : ControllerBase
    {
        private IDeposRepository repository;

        public DepositController(IDeposRepository repo)
        {
            repository = repo;
        }
        // GET: api/Deposit
        [HttpGet]
        public IEnumerable<Deposit> Get()
        {
            return repository.Deposits;
        }

        // GET: api/Deposit/5
        [HttpGet("{id}")]
        public Deposit Get(int id)
        {
            return repository.Get(id);
        }

        // POST: api/Deposit
        [HttpPost]
        public void Post([FromBody] Deposit acc)
        {
            repository.Add(acc);
        }

        // PUT: api/Deposit/5
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
