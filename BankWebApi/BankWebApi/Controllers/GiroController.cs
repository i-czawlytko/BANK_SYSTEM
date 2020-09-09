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
    public class GiroController : ControllerBase
    {
        // GET: api/Giro
        [HttpGet]
        public IEnumerable<Giros> Get()
        {
            return new DataContext().Giros;
        }

        // GET: api/Giro/5
        [HttpGet("{id}")]
        public Giros Get(int id)
        {
            return new DataContext().Giros.FirstOrDefault(e => e.id == id);
        }

        // POST: api/Giro
        [HttpPost]
        public void Post([FromBody] Giros acc)
        {
            using (var db = new DataContext())
            {
                db.Giros.Add(acc);
                db.SaveChanges();
            }
        }

        // PUT: api/Giro/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Giros new_acc)
        {
            using (var db = new DataContext())
            {
                Giros old_acc = db.Giros.FirstOrDefault(e => e.id == id);
                old_acc.amount = new_acc.amount;
                db.SaveChanges();
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
