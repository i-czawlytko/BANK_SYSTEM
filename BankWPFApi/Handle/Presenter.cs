using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using Calculate;
using System.Windows.Media;
using System.Data.Entity;
using System.Windows.Data;
using System.ComponentModel;

namespace Handle
{
    public static class Presenter
    {
        /// <summary>
        /// Реализация UI
        /// </summary>
        public static IMain MW { get; set; }
        static IModel model;
        

        /// <summary>
        /// Инициализация
        /// </summary>
        public static void Start()
        {
            model = new BankApi();

            model.GirosUpdated += MW.GirosRefresh;
            model.GirosUpdated += Presenter.LoadGiroInfo;
            MW.CompanyStack = new Stack<int>();
            MW.ParentID = 0;
        }

        /// <summary>
        /// Загрузка базы физ. лиц
        /// </summary>
        public static void LoadPhys()
        {
            MW.ClientNameHeader = "ФИО";
            MW.ClientDateHeader = "Дата рождения";

            MW.ClientSource = model.PhysClientsInit();

            MW.idBiding = new Binding("id");
            MW.nameBiding = new Binding("client_name");
            MW.dateBiding = new Binding("birth_date") { StringFormat = "dd.MM.yyyy" };

            MW.hierHide();
        }

        /// <summary>
        ///Защрузка базы юр.лиц 
        /// </summary>
        public static void LoadCompanys()
        {
            MW.ClientNameHeader = "Название";
            MW.ClientDateHeader = "Дата создания";

            MW.ClientSource = model.CompanyClientsInit(MW.ParentID);
         
            MW.idBiding = new Binding("id");
            MW.nameBiding = new Binding("company_name");
            MW.dateBiding = new Binding("create_date") { StringFormat = "dd.MM.yyyy" };

            MW.hierShow();

        }

        /// <summary>
        /// Загрузка списков аккаунтов
        /// </summary>
        public static void LoadClientAccounts()
        {
            int current_id;

            switch(MW.clientType() )
            {
                case "PHYS":
                    if (MW.current_phys is null) return;
                    current_id = MW.current_phys.id;
                    break;
                case "COMPANY":
                    if (MW.current_company is null) return;
                    current_id = MW.current_company.id;
                    break;
                default:
                    return;
            }

            MW.GiroSource = model.GirosAccsInit(MW.clientType(), current_id);
            MW.DeposSource = model.DepositAccsInit(MW.clientType(), current_id);
            MW.CreditSource = model.CreditAccsInit(MW.clientType(), current_id);


        }

        /// <summary>
        /// Загрузка информации о выбранном счете до востребования 
        /// </summary>
        public static void LoadGiroInfo(object _, EventArgs __)
        {
            try
            {
                switch (MW.clientType() )
                {
                    case "PHYS":
                        MW.GiroInfo = "Владелец: " + MW.current_phys.client_name + ", сумма на счете: " + MW.current_giros.amount.ToString();
                        break;
                    case "COMPANY":
                        MW.GiroInfo = "Владелец: " + MW.current_company.company_name + ", сумма на счете: " + MW.current_giros.amount.ToString();
                        break;
                    default:
                        return;
                }
            }
            catch(NullReferenceException)
            {
                MW.GiroInfo = "Счет не выбран";
            }
            
        }

        /// <summary>
        /// Метод для добавления денег на выбранный счет до востребования
        /// </summary>
        public static void GiroPut()
        {       
            model.Put(MW.current_giros, MW.TransferAmount);
        }

        /// <summary>
        /// Метод для снятия денег с выбранного счета до востребования
        /// </summary>
        public static void GiroWithdraw()
        {
            model.WithDraw(MW.current_giros, MW.TransferAmount);
        }

        /// <summary>
        /// Метод для отправки денег на указанный счет до востребования
        /// </summary>
        public static void GiroTransfer()
        {
            model.GiroTrans(MW.current_giros, MW.TransferAmount, MW.TransferID);
        }

        /// <summary>
        /// Метод вычисляет сумму на депозите у указанной дате
        /// </summary>
        public static void CalculateDeposit()
        {
            decimal? New_Amount;

            if (model.TryCalcDeposit(MW.current_deposits, MW.EstimateDate, out New_Amount))
            {
                MW.ProfitInfo = $"Сумма на предполагаемую дату снятия составляет: {New_Amount}";
            }
            else
            {
                MW.ProfitInfo = "Неверные данные для расчета";
            }
        }

        /// <summary>
        /// Метод подсчитывает сумму ежемесячного платежа по кредиту, при условии его погашения к указанной дате
        /// </summary>
        public static void CalculateCredit()
        {
            decimal? Month_Pay;

            if (model.TryCalcCredit(MW.current_credits, MW.RepaymentDate, out Month_Pay))
            {
                MW.CreditInfo = $"Ежемесячный платеж составляет: {Month_Pay}";
            }
            else
            {
                MW.CreditInfo = "Неверные данные для расчета";
            }
        }
        
        /// <summary>
        /// Метод добавляет клиента в банка (физ. лицо или юр.лицо)
        /// </summary>
        /// <param name="add_window"></param>
        public static void AddClient(IAdd add_window)
        {
            switch (MW.clientType() )
            {
                case "PHYS":
                    add_window.ITitle = "Добавление нового физ.лица";
                    add_window.nameText = "Имя";
                    add_window.lastNameText = "Фамилия";
                    add_window.dateText = "Дата рождения";
                    add_window.third_string_on = true;
                    break;
                case "COMPANY":
                    add_window.ITitle = "Добавление нового юр.лица";
                    add_window.nameText = "Название";
                    add_window.lastNameText = "-";
                    add_window.dateText = "Дата создания";
                    add_window.third_string_on = !true;
                    break;
                default:
                    MessageBox.Show("Не выбран тип клиент с которым следует работать");
                    return;
            }

            if (add_window.IShowDialog)
            {
                MW.ClientSource = model.ClientsCreator(add_window.dateString, add_window.fullNameString, MW.clientType(), MW.ParentID );
            }
            else
            {
                MessageBox.Show("Новый клиент не создан");
            }
        }
        
        /// <summary>
        /// Метод добавляет счет до востребования выбранному клиенту
        /// </summary>
        public static void AddGiro()
        {
            try
            {
                if (MW.clientType() is null) { MessageBox.Show("Клиент не выбран"); return; }
            }
            catch (InvalidCastException) { }

            int new_owner_id;

            switch (MW.clientType())
            {
                case "PHYS":
                    new_owner_id = MW.current_phys.id;
                    break;
                case "COMPANY":
                    new_owner_id = MW.current_company.id;
                    break;
                default:
                    return;
            }

            MW.GiroSource = model.GiroCreator(MW.clientType(),new_owner_id);
            
        }
        
        /// <summary>
        /// Метод добавляет депозит выбранному клиенту
        /// </summary>
        /// <param name="acc_window"></param>
        public static void AddDepos(IAddAccount acc_window)
        {
            try
            {
                if (MW.clientType() is null) { MessageBox.Show("Клиент не выбран"); return; }
            }
            catch (InvalidCastException) { }

            int new_owner_id;

            switch (MW.clientType())
            {
                case "PHYS":
                    new_owner_id = MW.current_phys.id;
                    break;
                case "COMPANY":
                    new_owner_id = MW.current_company.id;
                    break;
                default:
                    return;
            }

            acc_window.ITitle = "Открытие нового ДЕПОЗИТА";
            acc_window.ShowCheckBox();

            if (acc_window.IShowDialog)
            {
                try
                {
                    var new_coll = model.DeposCreator(MW.clientType(), new_owner_id, acc_window.amountString, acc_window.percentString, acc_window.Capitalization);

                    if (new_coll != null) MW.DeposSource = new_coll;
                }
                catch (FormatException)
                {
                    MessageBox.Show("Введены неверные данные");
                }               
            }
            else
            {
                MessageBox.Show("Новый депозит не открыт");
            }
        }
        
        /// <summary>
        /// Метод добавляет кредит выбранному клиенту
        /// </summary>
        /// <param name="acc_window"></param>
        public static void AddCredit(IAddAccount acc_window)
        {
            try
            {
                if (MW.current_phys is null && MW.current_company is null) { MessageBox.Show("Клиент не выбран"); return; }
            }
            catch (InvalidCastException) { }

            int new_owner_id;

            switch (MW.clientType())
            {
                case "PHYS":
                    new_owner_id = MW.current_phys.id;
                    break;
                case "COMPANY":
                    new_owner_id = MW.current_company.id;
                    break;
                default:
                    return;
            }

            acc_window.ITitle = "Открытие нового КРЕДИТА";
            acc_window.HideCheckBox();

            if (acc_window.IShowDialog)
            {
                try
                {
                    var new_coll = model.CreditCreator(MW.clientType(), new_owner_id, acc_window.amountString, acc_window.percentString);

                    if (new_coll != null) MW.CreditSource = new_coll;
                }
                catch (FormatException)
                {
                    MessageBox.Show("Введены неверные данные");
                }
            }
            else
            {
                MessageBox.Show("Новый кредит не открыт");
            }
        }

        public static void TransferBoxParser()
        {
            try
            {
                decimal Amount = decimal.Parse(MW.TransferAmount);
                if (Amount <= 0) throw new ArgumentOutOfRangeException();
                MW.TransferAmountBoxCol = Brushes.LightGreen;

            }
            catch (FormatException)
            {
                MW.TransferAmountBoxCol = Brushes.IndianRed;
            }
            catch (ArgumentOutOfRangeException)
            {
                MW.TransferAmountBoxCol = Brushes.IndianRed;
            }

        }

        public static void TransferIDBoxParser()
        {
            try
            {
                int.Parse(MW.TransferID);
                MW.TransferIDBoxCol = Brushes.LightGreen;
            }
            catch (FormatException)
            {
                MW.TransferIDBoxCol = Brushes.IndianRed;
            }
        }

        public static void goFrwd()
        {
            if (MW.current_company is null) return;

            MW.CompanyStack.Push(MW.ParentID);
            MW.ParentID = MW.current_company.id;
            MW.ClientSource = model.CompanyClientsInit(MW.ParentID);
        }

        public static void goBack()
        {
            if (MW.CompanyStack.Count == 0) return;

            MW.ParentID = MW.CompanyStack.Pop();
            MW.ClientSource = model.CompanyClientsInit(MW.ParentID);
        }

        public static void Update()
        {
            switch (MW.clientType())
            {
                case "PHYS":
                    MW.ClientSource = model.PhysClientsInit();
                    break;
                case "COMPANY":
                    MW.ClientSource = model.CompanyClientsInit(MW.ParentID);
                    break;
                default:
                    return;
            }
        }
    }
}
