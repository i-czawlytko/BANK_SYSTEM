using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Media;
using System.Windows.Data;
using System.Collections.ObjectModel;

namespace Handle
{
    public interface IMain
    {

        PhysClients current_phys { get; }
        CompanyClients current_company { get; }
        Giros current_giros { get; set; }
        Deposit current_deposits { get; }
        Credits current_credits { get; }



        /// <summary>
        /// Заголовок колонки с именем в таблице клентоа
        /// </summary>
        string ClientNameHeader { get; set; }

        /// <summary>
        /// Заголовок колонки с датой в таблице клентоа
        /// </summary>
        string ClientDateHeader { get; set; }


        /// <summary>
        /// Включает/выключает кнопку для добавления клиентов
        /// </summary>
        bool addClientBtnON { get; set; }

        /// <summary>
        /// Информация о выбранном счете до востребования
        /// </summary>
        string GiroInfo { get; set; }

        /// <summary>
        /// Сумма для перевода между счетами до востребования
        /// </summary>
        string TransferAmount { get; }

        /// <summary>
        /// Цвет текстбокса ввода сумма для счета до востребования
        /// </summary>
        Brush TransferAmountBoxCol { get; set; }

        /// <summary>
        /// Цвет текстбокса ID счета до востребования по которому нужно отправить сумму
        /// </summary>
        Brush TransferIDBoxCol { get; set; }

        /// <summary>
        /// id счета до востребования на который требуется отправить сумму
        /// </summary>
        string TransferID { get; }

        /// <summary>
        /// Строка с датой снятия депозита
        /// </summary>
        DateTime? EstimateDate { get; }

        /// <summary>
        /// Строка с датой выплаты кредита
        /// </summary>
        DateTime? RepaymentDate{ get; }

        /// <summary>
        /// Текст с информаций сумме на депозите к определенной дате
        /// </summary>
        string ProfitInfo { get; set; }

        /// <summary>
        /// Строка с информацией о сумме ежемесячных выплат по кредиту
        /// </summary>
        string CreditInfo { get; set; }

        /// <summary>
        /// Привязка списка клиентов
        /// </summary>
        System.Collections.IEnumerable ClientSource { get; set; }

        /// <summary>
        /// Привязка списка счетов до востребования
        /// </summary>
        System.Collections.IEnumerable GiroSource { get; set; }

        /// <summary>
        /// Привязка списка депозитов
        /// </summary>
        System.Collections.IEnumerable DeposSource { get; set; }

        /// <summary>
        /// Привязка списка кредитов
        /// </summary>
        System.Collections.IEnumerable CreditSource { get; set; }

        /// <summary>
        /// Поле привязвываемое к колонке id в списке клиентов
        /// </summary>
        BindingBase idBiding { get; set; }

        /// <summary>
        /// Поле привязвываемое к колонке name в списке клиентов
        /// </summary>
        BindingBase nameBiding { get; set; }

        /// <summary>
        /// Поле привязвываемое к колонке date в списке клиентов
        /// </summary>
        BindingBase dateBiding { get; set; }

        /// <summary>
        /// Обновление списка счетов до востребования
        /// </summary>
        void GirosRefresh(object _, EventArgs __);

        /// <summary>
        /// Обновления списка клиентов
        /// </summary>
        void ClientsRefresh();

        string clientType();

        void hierShow();

        void hierHide();

        Stack<int> CompanyStack { get; set; }

        int ParentID { get; set; }
    }
}
