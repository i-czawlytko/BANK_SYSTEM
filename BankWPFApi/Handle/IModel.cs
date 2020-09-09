using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Handle
{
    interface IModel
    {
        /// <summary>
        /// Событие связанное с обновлением счетов до востребования
        /// </summary>
        event EventHandler GirosUpdated;

        /// <summary>
        /// Метод кладет деньги на счет
        /// </summary>
        /// <param name="current_giro"></param>
        /// <param name="delta_amount"></param>
        void Put(Giros current_giro,string delta_amount);

        /// <summary>
        /// Метод снимает деньги со счета
        /// </summary>
        /// <param name="current_giro"></param>
        /// <param name="delta_amount"></param>
        void WithDraw(Giros current_giro, string delta_amount);

        /// <summary>
        /// Возвращает из базы коллекцию физ.лиц
        /// </summary>
        /// <returns></returns>
        System.Collections.IEnumerable PhysClientsInit();

        /// <summary>
        /// Возвращает из базы коллекцию юр.лиц
        /// </summary>
        /// <returns></returns>
        System.Collections.IEnumerable CompanyClientsInit(int parent_id = 0);

        /// <summary>
        /// Возвращает из базы коллекцию счетов до востребования
        /// </summary>
        /// <param name="client_type"></param>
        /// <param name="current_id"></param>
        /// <returns></returns>
        System.Collections.IEnumerable GirosAccsInit(string client_type, int current_id);

        /// <summary>
        /// Возвращает из базы коллекцию депозитов
        /// </summary>
        /// <param name="client_type"></param>
        /// <param name="current_id"></param>
        /// <returns></returns>
        System.Collections.IEnumerable DepositAccsInit(string client_type, int current_id);

        /// <summary>
        /// Возвращает из базы кредитов
        /// </summary>
        /// <param name="client_type"></param>
        /// <param name="current_id"></param>
        /// <returns></returns>
        System.Collections.IEnumerable CreditAccsInit(string client_type, int current_id);

        /// <summary>
        /// Метод переводит деньги с счета на счет
        /// </summary>
        /// <param name="current_giro"></param>
        /// <param name="trans_amount"></param>
        /// <param name="target_id_txt"></param>
        void GiroTrans(Giros current_giro, string trans_amount, string target_id_txt);

        /// <summary>
        /// Метод, создающий клиентов банка
        /// </summary>
        /// <param name="date_string"></param>
        /// <param name="fullname_string"></param>
        /// <param name="client_type"></param>
        System.Collections.IEnumerable ClientsCreator(string date_string, string fullname_string, string client_type, int parent_id = 0);

        /// <summary>
        /// Метод, считающий сумму на депозите к определенной дате
        /// </summary>
        /// <param name="current_depos"></param>
        /// <param name="estimate_date"></param>
        /// <param name="new_amount"></param>
        /// <returns></returns>
        bool TryCalcDeposit(Deposit current_depos, DateTime? estimate_date,out decimal? new_amount);

        /// <summary>
        /// Метод, вычисляющий ежемесячный платеж по кредиту
        /// </summary>
        /// <param name="current_credit"></param>
        /// <param name="repayment_date"></param>
        /// <param name="month_pay"></param>
        /// <returns></returns>
        bool TryCalcCredit(Credits current_credit, DateTime? repayment_date, out decimal? month_pay);

        /// <summary>
        /// Метод  создающий счет до востребования
        /// </summary>
        /// <param name="client_type"></param>
        /// <param name="new_owner_id"></param>
        /// <returns></returns>
        System.Collections.IEnumerable GiroCreator(string client_type, int new_owner_id);

        /// <summary>
        /// Метод, создающий депозит
        /// </summary>
        /// <param name="client_type"></param>
        /// <param name="new_owner_id"></param>
        /// <param name="amountString"></param>
        /// <param name="percentString"></param>
        /// <param name="capitalization"></param>
        /// <returns></returns>
        System.Collections.IEnumerable DeposCreator(string client_type, int new_owner_id, string amountString, string percentString, bool capitalization);

        /// <summary>
        /// Метод, создающий кредит
        /// </summary>
        /// <param name="client_type"></param>
        /// <param name="new_owner_id"></param>
        /// <param name="amountString"></param>
        /// <param name="percentString"></param>
        /// <returns></returns>
        System.Collections.IEnumerable CreditCreator(string client_type, int new_owner_id, string amountString, string percentString);
    }
}
