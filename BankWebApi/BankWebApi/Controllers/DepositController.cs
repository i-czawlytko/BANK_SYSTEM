using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankWebApi.Entitys;
using BankWebApi.ContextFolder;

namespace BankWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositController : ControllerBase
    {
        // GET: api/Deposit
        [HttpGet]
        public IEnumerable<Deposit> Get()
        {
            return new DataContext().Deposits;
        }

        // GET: api/Deposit/5
        [HttpGet("{id}")]
        public Deposit Get(int id)
        {
            return new DataContext().Deposits.FirstOrDefault(e => e.id == id);
        }

        // POST: api/Deposit
        [HttpPost]
        public void Post([FromBody] Deposit acc)
        {
            using (var db = new DataContext())
            {
                db.Deposits.Add(acc);
                db.SaveChanges();
            }
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
