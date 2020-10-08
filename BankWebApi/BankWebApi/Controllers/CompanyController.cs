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
    public class CompanyController : ControllerBase
    {
        private ICompanyRepository repository;

        public CompanyController(ICompanyRepository repo)
        {
            repository = repo;
        }

        // GET: api/Company
        [HttpGet]
        public IEnumerable<CompanyClients> Get()
        {
            return repository.Companies;
        }

        // GET: api/Company/5
        [HttpGet("{id}")]
        public CompanyClients Get(int id)
        {
            return repository.Get(id);
        }

        // POST: api/Company
        [HttpPost]
        public void Post([FromBody] CompanyClients client)
        {
            repository.Add(client);
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
