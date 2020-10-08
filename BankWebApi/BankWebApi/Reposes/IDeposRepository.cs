using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankWebApi.Entitys;

namespace BankWebApi.Reposes
{
    public interface IDeposRepository
    {
        IEnumerable<Deposit> Deposits { get; }
        Deposit Get(int id);
        void Add(Deposit acc);

    }
}
