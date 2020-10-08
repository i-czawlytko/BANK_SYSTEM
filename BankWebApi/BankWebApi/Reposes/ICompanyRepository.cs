using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankWebApi.Entitys;

namespace BankWebApi.Reposes
{
    public interface ICompanyRepository
    {
        IEnumerable<CompanyClients> Companies { get; }
        CompanyClients Get(int id);
        void Add(CompanyClients client);

    }
}
