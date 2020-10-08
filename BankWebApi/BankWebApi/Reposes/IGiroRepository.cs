using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankWebApi.Entitys;

namespace BankWebApi.Reposes
{
    public interface IGiroRepository
    {
        IEnumerable<Giros> Giros { get; }
        Giros Get(int id);
        void Add(Giros acc);
        void Put(int id, Giros acc);

    }
}
