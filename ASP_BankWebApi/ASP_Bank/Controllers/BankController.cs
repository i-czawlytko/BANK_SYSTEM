using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP_Bank.Entitys;
using ASP_Bank.ContextFolder;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ASP_Bank.Controllers
{
    public class BankController : Controller
    {
        private HttpClient httpClient = new HttpClient();


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Clients(string client_type,int parent_id=0)
        {
            ViewBag.client_type = client_type;

            ViewBag.PhysClients = DataContext.GetAllPhys(this.httpClient);

            ViewBag.CompanyClients = DataContext.GetAllCompanies(this.httpClient).Where(e => e.parent_id == parent_id);

            ViewBag.ParentID = parent_id;
            var parent_comp = DataContext.GetAllCompanies(this.httpClient).FirstOrDefault(e => e.id == parent_id);
            if (!(parent_comp is null)) ViewBag.ParentName = parent_comp.company_name;

            else ViewBag.ParentName = "empty";
            return View();
        }

        [HttpGet]
        public ActionResult Accounts(string client_type, int cl_id, string account_type = "empty")
        {
            ViewBag.client_type = client_type;
            ViewBag.client_id = cl_id;

            ViewBag.ClientName = "empty";

            if (client_type == "phys")
            {
                var CurrentClient = DataContext.GetAllPhys(this.httpClient).First(e => e.id == cl_id);
                ViewBag.ClientName = CurrentClient.client_name;
            }
            else if (client_type == "company")
            {
                var CurrentClient = DataContext.GetAllCompanies(this.httpClient).First(e => e.id == cl_id);
                ViewBag.ClientName = CurrentClient.company_name;
            }

            ViewBag.Giros = DataContext.GetAllGiros(this.httpClient).Where(e => e.owner_id == cl_id && e.owner_type == client_type.ToUpper());
            ViewBag.Deposits = DataContext.GetAllDeposits(this.httpClient).Where(e => e.owner_id == cl_id && e.owner_type == client_type.ToUpper());
            ViewBag.Credits = DataContext.GetAllCredits(this.httpClient).Where(e => e.owner_id == cl_id && e.owner_type == client_type.ToUpper());

            ViewBag.AccountType = account_type;

            return View();
        }
    }
}