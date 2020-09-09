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
    public class CompanyController : ControllerBase
    {
        // GET: api/Company
        [HttpGet]
        public IEnumerable<CompanyClients> Get()
        {
            return new DataContext().CompanyClients;
        }

        // GET: api/Company/5
        [HttpGet("{id}")]
        public CompanyClients Get(int id)
        {
            return new DataContext().CompanyClients.FirstOrDefault(e => e.id == id);
        }

        // POST: api/Company
        [HttpPost]
        public void Post([FromBody] CompanyClients client)
        {
            using (var db = new DataContext())
            {
                db.CompanyClients.Add(client);
                db.SaveChanges();
            }
        }

        // PUT: api/Company/5
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
