﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Bank.Entitys
{
    public class Deposit
    {
        public int id { get; set; }
        public int owner_id { get; set; }
        public decimal amount { get; set; }
        public System.DateTime create_date { get; set; }
        public bool cap { get; set; }
        public string owner_type { get; set; }
        public int percent { get; set; }
    }
}
