using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BankWebApi.Reposes;
using BankWebApi.Entitys;

namespace BankWebApi.ContextFolder
{
    public class EFCredits : ICreditRepository
    {
        private DataContext context;

        public EFCredits(DataContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Credits> Credits => context.Credits.ToArray();

        public Credits Get(int id)
        {
            return context.Credits.FirstOrDefault(a => a.id == id);
        }


        public void Add(Credits acc)
        {
            context.Credits.Add(acc);
            context.SaveChanges();
        }
    }
}
