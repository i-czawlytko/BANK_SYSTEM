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
    public class CreditController : ControllerBase
    {
        // GET: api/Credit
        [HttpGet]
        public IEnumerable<Credits> Get()
        {
            return new DataContext().Credits;
        }

        // GET: api/Credit/5
        [HttpGet("{id}")]
        public Credits Get(int id)
        {
            return new DataContext().Credits.FirstOrDefault(e => e.id == id);
        }

        // POST: api/Credit
        [HttpPost]
        public void Post([FromBody] Credits acc)
        {
            using (var db = new DataContext())
            {
                db.Credits.Add(acc);
                db.SaveChanges();
            }
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
