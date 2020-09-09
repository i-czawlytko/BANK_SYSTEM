using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP_Bank.ContextFolder;
using ASP_Bank.Entitys;
using System.Web;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;

namespace ASP_Bank.Controllers
{
    [Authorize]
    public class AddController : Controller
    {
        private HttpClient httpClient = new HttpClient();
        public IActionResult phys()
        {
            return View();
        }

        public IActionResult company(int parent_id)
        {
            ViewBag.ParentID = parent_id;
            return View();
        }

        public IActionResult deposit(string client_type, int client_id)
        {
            ViewBag.ClientType = client_type;
            ViewBag.ClientID = client_id;
            return View();
        }

        public IActionResult credit(string client_type, int client_id)
        {
            ViewBag.ClientType = client_type;
            ViewBag.ClientID = client_id;
            return View();
        }


        public IActionResult GetDataFromViewField(string client_type, string fullName, DateTime birthDate, int _parent_id = 0)
        {
            if (client_type == "phys")
            {
                PhysClients new_client = new PhysClients
                {
                    client_name = fullName,
                    birth_date = birthDate
                };

                DataContext.SendPhys(httpClient, new_client);

                return Redirect("/Bank/Clients?client_type=phys");
            }
            else if (client_type == "company")
            {
                CompanyClients new_client = new CompanyClients
                {
                    company_name = fullName,
                    create_date = birthDate,
                    parent_id = _parent_id
                };

                DataContext.SendCompany(httpClient, new_client);


                return Redirect($"/Bank/Clients?client_type=company&parent_id={_parent_id}");
            }
            else
            {
                return Redirect("~/");
            }
        }

        public IActionResult GetAccFromViewField(string acc_type, string client_type, int client_id, int new_percent = 0, decimal new_amount = 0, bool new_cap = false)
        {
            if (acc_type == "giro")
            {
                Giros new_acc = new Giros
                {
                    owner_id = client_id,
                    owner_type = client_type.ToUpper(),
                    create_date = DateTime.Today,
                    amount = 0
                };

                DataContext.SendGiro(httpClient, new_acc);

                return Redirect($"/Bank/Accounts?client_type={client_type}&cl_id={client_id}&account_type=giro");
            }
            else if (acc_type == "deposit")
            {
                Deposit new_acc = new Deposit
                {
                    amount = new_amount,
                    percent = new_percent,
                    owner_id = client_id,
                    owner_type = client_type.ToUpper(),
                    cap = new_cap,
                    create_date = DateTime.Today
                };

                DataContext.SendDeposit(httpClient, new_acc);

                return Redirect($"/Bank/Accounts?client_type={client_type}&cl_id={client_id}&account_type=deposit");
            }
            else if (acc_type == "credit")
            {
                Credits new_acc = new Credits
                {
                    amount = new_amount,
                    owner_id = client_id,
                    owner_type = client_type.ToUpper(),
                    percent = new_percent,
                    create_date = DateTime.Today
                };

                DataContext.SendCredit(httpClient, new_acc);

                return Redirect($"/Bank/Accounts?client_type={client_type}&cl_id={client_id}&account_type=credit");
            }
            else
            {
                return Redirect("~/");
            }
        }
    }
}