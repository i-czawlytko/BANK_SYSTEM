using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankWebApi.Entitys;
using BankWebApi.ContextFolder;

namespace BankWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhysController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<PhysClients>> Get()
        {
            return new DataContext().PhysClients;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public PhysClients Get(int id)
        {
            return new DataContext().PhysClients.FirstOrDefault(e => e.id == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] PhysClients client)
        {
            using (var db = new DataContext())
            {
                db.PhysClients.Add(client);
                 db.SaveChanges();
            }
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
