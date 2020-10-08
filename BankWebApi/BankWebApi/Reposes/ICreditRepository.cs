using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankWebApi.Entitys;

namespace BankWebApi.Reposes
{
    public interface ICreditRepository
    {
        IEnumerable<Credits> Credits { get; }
        Credits Get(int id);
        void Add(Credits acc);

    }
}
