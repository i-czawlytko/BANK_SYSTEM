using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BankWebApi.Reposes;
using BankWebApi.Entitys;

namespace BankWebApi.ContextFolder
{
    public class EFGiros : IGiroRepository
    {
        private DataContext context;

        public EFGiros(DataContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Giros> Giros => context.Giros.ToArray();

        public Giros Get(int id)
        {
            return context.Giros.FirstOrDefault(a => a.id == id);
        }


        public void Add(Giros acc)
        {
            context.Giros.Add(acc);
            context.SaveChanges();
        }

        public void Put(int id, Giros new_acc)
        {
            Giros old_acc = context.Giros.FirstOrDefault(e => e.id == id);
            old_acc.amount = new_acc.amount;
            context.SaveChanges();
        }
    }
}
