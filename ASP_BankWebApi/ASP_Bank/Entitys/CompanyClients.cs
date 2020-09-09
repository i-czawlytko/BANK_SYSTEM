using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Bank.Entitys
{
    public class CompanyClients
    {
        public int id { get; set; }
        public string company_name { get; set; }
        public System.DateTime create_date { get; set; }

        public int parent_id { get; set; }
    }
}
