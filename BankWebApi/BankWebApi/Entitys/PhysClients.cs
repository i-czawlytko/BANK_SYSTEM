using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebApi.Entitys
{
    public class PhysClients
    {
        public int id { get; set; }
        public string client_name { get; set; }
        public System.DateTime birth_date { get; set; }
    }
}
