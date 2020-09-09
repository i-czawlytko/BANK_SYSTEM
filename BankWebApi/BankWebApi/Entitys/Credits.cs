using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebApi.Entitys
{
    public class Credits
    {
        public int id { get; set; }
        public int owner_id { get; set; }
        public decimal amount { get; set; }
        public System.DateTime create_date { get; set; }
        public int percent { get; set; }
        public string owner_type { get; set; }
    }
}
