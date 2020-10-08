using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BankWebApi.Reposes;
using BankWebApi.Entitys;

namespace BankWebApi.ContextFolder
{
    public class EFDepos : IDeposRepository
    {
        private DataContext context;

        public EFDepos(DataContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Deposit> Deposits => context.Deposits.ToArray();

        public Deposit Get(int id)
        {
            return context.Deposits.FirstOrDefault(a => a.id == id);
        }


        public void Add(Deposit acc)
        {
            context.Deposits.Add(acc);
            context.SaveChanges();
        }
    }
}
