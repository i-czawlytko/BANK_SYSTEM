using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;
using System.Collections.ObjectModel;
using Handle;

namespace BankADO
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMain
    {
        #region реализация интерфейсов


        public PhysClients current_phys { get {return (PhysClients)this.clientList.SelectedItem; } }
        public CompanyClients current_company { get { return (CompanyClients)this.clientList.SelectedItem; } }

        public Giros current_giros { get { return (Giros)this.giroList.SelectedItem; } set { } }
        public Deposit current_deposits { get { return (Deposit)this.deposList.SelectedItem; } }
        public Credits current_credits { get { return (Credits)this.creditList.SelectedItem; } }

        public Stack<int> CompanyStack { get; set; }


        public string ClientNameHeader { get { return (string)cl_name_view.Header; } set { cl_name_view.Header = value; } }
        public string ClientDateHeader { get { return (string)cl_date_view.Header; } set { cl_date_view.Header = value; } }

        public bool addClientBtnON { get { return addClientBtn.IsEnabled; } set { addClientBtn.IsEnabled = value ; } }
        public string GiroInfo { get { return giro_amount.Text; } set { giro_amount.Text = value; } }

        public string TransferAmount { get { return giro_tb.Text; }  }

        public string TransferID { get { return giro_id.Text; } }

        public DateTime? EstimateDate { get {return (DateTime?)this.deposCalendar.SelectedDate;} }
        public DateTime? RepaymentDate { get { return (DateTime?)this.creditCalendar.SelectedDate; } }
        public string ProfitInfo { get {return this.profit_text.Text;} set { this.profit_text.Text = value; } }
        public string CreditInfo { get { return this.credit_text.Text; } set { this.credit_text.Text = value; } }

        public Brush TransferAmountBoxCol { get { return giro_tb.Background; } set { giro_tb.Background = value; } }

        public Brush TransferIDBoxCol { get { return giro_id.Background; } set { giro_id.Background = value; } }

        public System.Collections.IEnumerable ClientSource { get { return clientList.ItemsSource; } set { clientList.ItemsSource = value; } }
        public System.Collections.IEnumerable GiroSource { get { return giroList.ItemsSource; } set { giroList.ItemsSource = value; } }
        public System.Collections.IEnumerable DeposSource { get { return deposList.ItemsSource; } set { deposList.ItemsSource = value; } }
        public System.Collections.IEnumerable CreditSource { get { return creditList.ItemsSource; } set { creditList.ItemsSource = value; } }


        public BindingBase idBiding { get { return cl_id_view.DisplayMemberBinding; } set { cl_id_view.DisplayMemberBinding = value; } }
        public BindingBase nameBiding { get { return cl_name_view.DisplayMemberBinding; } set { cl_name_view.DisplayMemberBinding = value; } }
        public BindingBase dateBiding { get { return cl_date_view.DisplayMemberBinding; } set { cl_date_view.DisplayMemberBinding = value; } }
        public void GirosRefresh(object _, EventArgs __)
        {
            this.giroList.Items.Refresh();
        }
        public void ClientsRefresh()
        {
            this.clientList.Items.Refresh();
        }

        public void hierShow()
        {
            backBtn.Visibility = Visibility.Visible;
            frwdBtn.Visibility = Visibility.Visible;
        }

        public void hierHide()
        {
            backBtn.Visibility = Visibility.Hidden;
            frwdBtn.Visibility = Visibility.Hidden;
        }

        public int ParentID { get; set; }

        #endregion
        public string clientType()
        {
            if (this.phys_radio.IsChecked == true)
            {
                return "PHYS";
            }
            else if(this.company_radio.IsChecked == true)
            {
                return "COMPANY";
            }
            else
            {
                return null;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            Preparing();
        }

        /// <summary>
        /// Подготовка к запуску приложения
        /// </summary>
        public void Preparing()
        {
            Presenter.MW = this;
            Presenter.Start();
            
        }

        private void PhysClick(object sender, RoutedEventArgs e)
        {
            Presenter.LoadPhys();

        }

        private void CompanyClick(object sender, RoutedEventArgs e)
        {
            Presenter.LoadCompanys();
        }

        private void GiroList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Presenter.LoadGiroInfo(sender,e);
        }

        private void ClientList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Presenter.LoadClientAccounts();
        }

        private void GiroPutClick(object sender, RoutedEventArgs e)
        {
            Presenter.GiroPut();
        }

        private void GiroTransferClick(object sender, RoutedEventArgs e)
        {
            Presenter.GiroTransfer();
        }

        private void calc_profit_click(object sender, RoutedEventArgs e)
        {
            Presenter.CalculateDeposit();
        }

        private void calc_credit_click(object sender, RoutedEventArgs e)
        {
            Presenter.CalculateCredit();
        }

        private void addClientClick(object sender, RoutedEventArgs e)
        {
            Presenter.AddClient(new AddWindow());
        }

        private void GiroCreateClick(object sender, RoutedEventArgs e)
        {
            Presenter.AddGiro();
        }

        private void addDeposClick(object sender, RoutedEventArgs e)
        {
           Presenter.AddDepos(new AddAcount());
        }

        private void addCreditClick(object sender, RoutedEventArgs e)
        {
            Presenter.AddCredit(new AddAcount());
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
        }

        private void Giro_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Presenter.TransferBoxParser();
        }

        private void Giro_id_TextChanged(object sender, TextChangedEventArgs e)
        {
           Presenter.TransferIDBoxParser();
        }

        private void GiroWithdrawClick(object sender, RoutedEventArgs e)
        {
           Presenter.GiroWithdraw();
        }

        private void Phys_radio_Checked(object sender, RoutedEventArgs e)
        {
            Presenter.LoadPhys();
        }

        private void Company_radio_Checked(object sender, RoutedEventArgs e)
        {
            Presenter.LoadCompanys();
        }

        private void frwdClick(object sender, RoutedEventArgs e)
        {
            Presenter.goFrwd();
        }

        private void backClick(object sender, RoutedEventArgs e)
        {
            Presenter.goBack();
        }

        private void updClientClick(object sender, RoutedEventArgs e)
        {
            Presenter.Update();
        }
    }
}
