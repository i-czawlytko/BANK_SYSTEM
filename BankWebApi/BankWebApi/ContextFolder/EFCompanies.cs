using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BankWebApi.Reposes;
using BankWebApi.Entitys;

namespace BankWebApi.ContextFolder
{
    public class EFCompanies : ICompanyRepository
    {
        private DataContext context;

        public EFCompanies(DataContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<CompanyClients> Companies => context.CompanyClients.ToArray();

        public CompanyClients Get(int id)
        {
            return context.CompanyClients.FirstOrDefault(a => a.id == id);
        }


        public void Add(CompanyClients company)
        {
            context.CompanyClients.Add(company);
            context.SaveChanges();
        }
    }
}
