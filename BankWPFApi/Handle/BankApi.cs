using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows;
using Calculate;
using System.Collections.ObjectModel;
using Handle.Context;
using System.Net.Http;
using System.Configuration;


namespace Handle
{
    class BankApi : IModel
    {
        decimal db_amount_limit = (decimal)Math.Pow(10, 16) - 1;

        private HttpClient httpClient;

        public event EventHandler GirosUpdated;
        public BankApi()
        {
            httpClient = new HttpClient();
            DataContext.server_adress = ConfigurationManager.AppSettings["server_adress"];          
        }

        public System.Collections.IEnumerable PhysClientsInit()
        {
            return DataContext.GetAllPhys(httpClient);
        }

        public System.Collections.IEnumerable CompanyClientsInit(int parent_id = 0)
        {
            return DataContext.GetAllCompanies(httpClient).Where(e => e.parent_id == parent_id);
        }

        public System.Collections.IEnumerable GirosAccsInit(string client_type, int current_id)
        {
            if (!(client_type is null))
            {
                return DataContext.GetAllGiros(httpClient).Where(e => e.owner_id == current_id && e.owner_type == client_type);
            }
            else
            {
                return null;
            }
        }

        public System.Collections.IEnumerable DepositAccsInit(string client_type, int current_id)
        {

            if (!(client_type is null))
            {
                return DataContext.GetAllDeposits(httpClient).Where(e => e.owner_id == current_id && e.owner_type == client_type);
            }
            else
            {
                return null;
            }
        }

        public System.Collections.IEnumerable CreditAccsInit(string client_type, int current_id)
        {
            if (!(client_type is null))
            {
                return DataContext.GetAllCredits(httpClient).Where(e => e.owner_id == current_id && e.owner_type == client_type);
            }
            else
            {
                return null;
            }
        }
        public void Put(Giros current_giro, string delta_amount)
        {
            if (current_giro is null) { MessageBox.Show("Счет до востребования не выбран"); return; }

            decimal Amount = 0;

            if (!decimal.TryParse(delta_amount, out Amount)) { System.Windows.MessageBox.Show("Сумма указана неверно"); return; }

            if (Amount <= 0) { System.Windows.MessageBox.Show("Сумма должна быть больше нуля"); return; }

            if (current_giro.amount + Amount > this.db_amount_limit) { System.Windows.MessageBox.Show("На счету не может храниться такая большая сумма"); return; }

            current_giro.amount += decimal.Round(Amount, 2);

            GirosUpdated(this, new EventArgs());

            DataContext.PutGiro(httpClient, current_giro);

        }

        public void WithDraw(Giros current_giro, string delta_amount)
        {
            if (current_giro is null) { MessageBox.Show("Счет до востребования не выбран"); return; }

            decimal Amount = 0;

            if (!decimal.TryParse(delta_amount, out Amount)) { System.Windows.MessageBox.Show("Сумма указана неверно"); return; }

            if (Amount <= 0) { System.Windows.MessageBox.Show("Сумма должна быть больше нуля"); return; }

            if (current_giro.amount < Amount) { System.Windows.MessageBox.Show("На сумма на счете меньше указанной"); return; }

            current_giro.amount -= decimal.Round(Amount, 2);

            GirosUpdated(this, new EventArgs());

            DataContext.PutGiro(httpClient, current_giro);

        }

        public void GiroTrans(Giros current_giro, string trans_amount, string target_id_txt)
        {
            if (current_giro is null) { MessageBox.Show("Счет до востребования не выбран"); return; }

            decimal Amount = 0;
            if (!decimal.TryParse(trans_amount, out Amount)) { MessageBox.Show("Сумма указана неверно"); return; }

            if (Amount <= 0) { MessageBox.Show("Сумма должна быть больше нуля"); return; }

            if (current_giro.amount < Amount) { MessageBox.Show("На сумма на счете меньше указанной"); return; }

            if (current_giro.amount + Amount > db_amount_limit) { MessageBox.Show("На целевом счете не может храниться такая большая сумма"); return; }

            int target_id = 0;
            if (!int.TryParse(target_id_txt, out target_id)) { MessageBox.Show("ID должен быть числом"); return; }

            try
            {
                //var target_giro = this.context.Giros.First(x => x.id == target_id);
                var target_giro = DataContext.GetGiro(httpClient, target_id);

                current_giro.amount -= decimal.Round(Amount, 2);

                target_giro.amount += decimal.Round(Amount, 2);

                GirosUpdated(this, new EventArgs());

                DataContext.PutGiro(httpClient, current_giro);
                DataContext.PutGiro(httpClient, target_giro);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Счета с указанным ID не существует");
            }

        }

        public System.Collections.IEnumerable ClientsCreator(string date_string, string fullname_string, string client_type, int parent_id = 0)
        {
            try
            {
                switch(client_type)
                {
                    case "PHYS":
                        DataContext.SendPhys(httpClient, (PhysClients)ClientFactory.GetClient(client_type, fullname_string, date_string));
                        return DataContext.GetAllPhys(httpClient);
                    case "COMPANY":
                        DataContext.SendCompany(httpClient, (CompanyClients)ClientFactory.GetClient(client_type, fullname_string, date_string, parent_id));
                        return DataContext.GetAllCompanies(httpClient).Where(e => e.parent_id == parent_id);
                    default: return null;
                }
 
                //this.context.SaveChanges();

            }
            catch (ArgumentException)
            {
                MessageBox.Show("Введены неверные данные");
                return null;
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверная дата");
                return null;
            }
        }

        public bool TryCalcDeposit(Deposit current_depos, DateTime? estimate_date, out decimal? new_amount)
        {
            new_amount = null;
            try
            {
                if (current_depos is null) { MessageBox.Show("Депозит не выбран"); return false; }
                if (estimate_date is null) { MessageBox.Show("Дата не выбрана"); return false; }

                DateTime open_date = current_depos.create_date;
                bool flag = current_depos.cap;
                decimal amount = current_depos.amount;
                int percent = current_depos.percent;

                if (open_date >= (DateTime)estimate_date) throw new BadDateException("Неверная дата");

                new_amount = Calc.Deposit(flag, amount, open_date, (DateTime)estimate_date, percent);
                
                return true;
            }
            catch (FormatException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            catch (BadDateException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }          
        }

        public bool TryCalcCredit(Credits current_credit, DateTime? repayment_date, out decimal? month_pay)
        {
            month_pay = null;
            try
            {
                if (current_credit is null) { MessageBox.Show("Кредит не выбран"); return false; }
                if (repayment_date is null) { MessageBox.Show("Дата не выбран"); return false; }

                DateTime open_date = current_credit.create_date;
                decimal amount = current_credit.amount;
                int percent = current_credit.percent;

                if (open_date >= (DateTime)repayment_date) throw new BadDateException("Неверная дата");

                month_pay = Calc.Credit(amount, open_date, (DateTime)repayment_date, percent);
                return true;
            }
            catch (FormatException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            catch (BadDateException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

        }
        public System.Collections.IEnumerable GiroCreator(string client_type, int new_owner_id)
        {

            Giros new_giro = new Giros { amount = 0.00M, create_date = DateTime.Today, owner_id = new_owner_id, owner_type = client_type };

            //context.Giros.Add(new_giro);
            DataContext.SendGiro(httpClient,new_giro);
            
            //this.context.SaveChanges();

            if (!(client_type is null))
            {
                return DataContext.GetAllGiros(httpClient).Where(e => e.owner_id == new_owner_id && e.owner_type == client_type);
            }
            else
            {
                return null;
            }
        }
        public System.Collections.IEnumerable DeposCreator(string client_type, int new_owner_id, string amountString, string percentString, bool capitalization)
        {
            decimal Amount = decimal.Parse(amountString);
            int Percent = int.Parse(percentString);

            if (Amount <= 0) { MessageBox.Show("Сумма на депозите должна быть больше нуля"); return null; }

            if (Amount > db_amount_limit) { MessageBox.Show("Столько денег нельзя положить на депозит"); return null; }

            Deposit new_depos = new Deposit { amount = Amount, cap = capitalization, owner_id = new_owner_id, owner_type = client_type, create_date = DateTime.Today, percent = Percent };

            //context.Deposit.Add(new_depos);

            //context.SaveChanges();

            DataContext.SendDeposit(httpClient, new_depos);

            if (!(client_type is null))
            {
                return DataContext.GetAllDeposits(httpClient).Where(e => e.owner_id == new_owner_id && e.owner_type == client_type);
            }
            else
            {
                return null;
            }
        }

        public System.Collections.IEnumerable CreditCreator(string client_type, int new_owner_id, string amountString, string percentString)
        {

            decimal Amount = decimal.Parse(amountString);
            if (Amount <= 0) { MessageBox.Show("Сумма кредита должна быть больше нуля"); return null; }
            int Percent = int.Parse(percentString);

            if (Amount > db_amount_limit) { MessageBox.Show("Нельзя взять кредит на такую большую сумму"); return null; }

            Credits new_credit = new Credits { amount = Amount, owner_type = client_type, owner_id = new_owner_id, create_date = DateTime.Today, percent = Percent };

            //context.Credits.Add(new_credit);

            //context.SaveChanges();
            DataContext.SendCredit(httpClient, new_credit);

            if (!(client_type is null))
            {
                return DataContext.GetAllCredits(httpClient).Where(e => e.owner_id == new_owner_id && e.owner_type == client_type);
            }
            else
            {
                return null;
            }
        }
    }
}
