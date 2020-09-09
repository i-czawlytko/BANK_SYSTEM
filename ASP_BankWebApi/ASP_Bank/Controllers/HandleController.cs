using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP_Bank.Entitys;
using ASP_Bank.ContextFolder;
using Microsoft.AspNetCore.Http;
using Calculate;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;

namespace ASP_Bank.Controllers
{
    [Authorize]
    public class HandleController : Controller
    {
        private HttpClient httpClient = new HttpClient();
        decimal max_amount = (decimal)(Math.Pow(10.0, 16.0) - 1.0);
        public ActionResult giro(string client_type, int acc_id, string query_type, decimal? amount, int? target_id)
        {
            int owner_id = DataContext.GetGiro(httpClient,acc_id).owner_id;

            ViewBag.owner_name = "empty";
            ViewBag.AccID = acc_id;
            
            
            if (client_type == "phys")
            {               
                ViewBag.owner_name = DataContext.GetPhys(httpClient,owner_id).client_name;
            }
            else if (client_type == "company")
            {
                ViewBag.owner_name = DataContext.GetCompany(httpClient, owner_id).company_name;
            }
            
            if(query_type == "put")
            {
                ViewBag.Message = Put(acc_id, (decimal)amount);
            }
            else if (query_type == "withdraw")
            {
                ViewBag.Message = Withdraw(acc_id, (decimal)amount);
            }
            else if (query_type == "transfer")
            {
                ViewBag.Message = Transfer(acc_id, (int) target_id,(decimal)amount);
            }
            ViewBag.CurrentAmount = DataContext.GetGiro(httpClient,acc_id).amount;
            return View();
        }

        public ActionResult deposit(string client_type, int acc_id, DateTime? est_date)
        {
            //ViewBag.CurrentDepos = new DataContext().Deposits.First(e => e.id == acc_id);
            ViewBag.CurrentDepos = DataContext.GetDeposit(httpClient, acc_id);
            int owner_id = ViewBag.CurrentDepos.owner_id;
            ViewBag.owner_name = "empty";
            ViewBag.AccID = acc_id;
            ViewBag.ClientType = client_type;

            if (client_type == "phys")
            {
                //ViewBag.owner_name = new DataContext().PhysClients.First(e => e.id == owner_id).client_name;
                ViewBag.owner_name = DataContext.GetPhys(httpClient, owner_id).client_name;
            }
            else if (client_type == "company")
            {
                ViewBag.owner_name = DataContext.GetCompany(httpClient, owner_id).company_name;
            }

            if (!(est_date is null))
            {
                ViewBag.EstAmount = Calc.Deposit(ViewBag.CurrentDepos.cap, ViewBag.CurrentDepos.amount, ViewBag.CurrentDepos.create_date,(DateTime)est_date, ViewBag.CurrentDepos.percent);
            }
            
            return View();
        }

        public ActionResult credit(string client_type, int acc_id, DateTime? est_date)
        {
            ViewBag.CurrentCredit = DataContext.GetCredit(httpClient, acc_id);
            int owner_id = ViewBag.CurrentCredit.owner_id;
            ViewBag.owner_name = "empty";
            ViewBag.AccID = acc_id;
            ViewBag.ClientType = client_type;

            if (client_type == "phys")
            {
                ViewBag.owner_name = DataContext.GetPhys(httpClient, owner_id).client_name;
            }
            else if (client_type == "company")
            {
                ViewBag.owner_name = DataContext.GetCompany(httpClient, owner_id).company_name;
            }

            if (!(est_date is null))
            {
                ViewBag.EstAmount = Calc.Credit(ViewBag.CurrentCredit.amount, ViewBag.CurrentCredit.create_date, (DateTime)est_date, ViewBag.CurrentCredit.percent);
            }

            return View();
        }
        public string Transfer(int sender_id, int target_id, decimal amount)
        {
            var sender_acc = DataContext.GetGiro(httpClient, sender_id);
            var target_acc = DataContext.GetGiro(httpClient, target_id);

            if (target_acc is null)
            {
                return $"Не существует счета с ID:{target_id}";
            }
            else if (amount <= 0)
            {
                return "Указанная сумма должна быть больше нуля";
            }
            else if (sender_acc.amount < amount)
            {
                return "На счету недостаточно средств";
            }
            else if ((target_acc.amount + amount) >= max_amount)
            {
                return "На счету не может храниться столько средств";
            }
            else
            {
                sender_acc.amount -= amount;
                target_acc.amount += amount;
                DataContext.PutGiro(httpClient, sender_acc);
                DataContext.PutGiro(httpClient, target_acc);

                return $"{amount} рублей успешно отправлены на счет (ID:{target_id})";
            }
                           
        }

        public string Put(int sender_id, decimal amount)
        {

            //var sender_acc = db.Giros.First(e => e.id == sender_id);
            var sender_acc = DataContext.GetGiro(httpClient, sender_id);

            if (amount <= 0)
            {
                return "Указанная сумма должна быть больше нуля";
            }
            else if ((sender_acc.amount + amount) >= max_amount)
            {
                return "На счету не может храниться столько средств";
            }
            else
            {
                sender_acc.amount += amount;

                DataContext.PutGiro(httpClient, sender_acc);

                return $"{amount} рублей успешно положены на счет";
            }
          
        }

        public string Withdraw(int sender_id, decimal amount)
        {
            var sender_acc = DataContext.GetGiro(httpClient, sender_id);

            if (amount <= 0)
            {
                return "Указанная сумма должна быть больше нуля";
            }
            else if (sender_acc.amount < amount)
            {
                return "На счету не достаточно средств";
            }
            else
            {
                sender_acc.amount -= amount;

                DataContext.PutGiro(httpClient, sender_acc);

                return $"{amount} рублей успешно сняты со счета";
            }
        }
    }
}