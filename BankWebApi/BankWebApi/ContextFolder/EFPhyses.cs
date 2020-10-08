using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BankWebApi.Reposes;
using BankWebApi.Entitys;

namespace BankWebApi.ContextFolder
{
    public class EFPhyses : IPhysRepository
    {
        private DataContext context;

        public EFPhyses(DataContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<PhysClients> Physes => context.PhysClients.ToArray();

        public PhysClients Get(int id)
        {
            return context.PhysClients.FirstOrDefault(a => a.id == id);
        }


        public void Add(PhysClients phys)
        {
            context.PhysClients.Add(phys);
            context.SaveChanges();
        }
    }
}
