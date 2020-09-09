using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_Bank.Views.Bank
{
    public class Giros
    {
        public int id { get; set; }
        public int owner_id { get; set; }
        public decimal amount { get; set; }
        public System.DateTime create_date { get; set; }
        public string owner_type { get; set; }
    }
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}