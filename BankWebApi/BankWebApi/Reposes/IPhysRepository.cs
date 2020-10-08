using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankWebApi.Entitys;

namespace BankWebApi.Reposes
{
    public interface IPhysRepository
    {
        IEnumerable<PhysClients> Physes { get; }
        PhysClients Get(int id);
        void Add(PhysClients client);

    }
}
