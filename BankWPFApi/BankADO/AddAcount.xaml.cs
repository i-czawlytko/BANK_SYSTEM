using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Handle;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BankADO
{
    /// <summary>
    /// Логика взаимодействия для AddAcount.xaml
    /// </summary>
    public partial class AddAcount : Window, IAddAccount
    {
        public bool IShowDialog { get { return (bool)this.ShowDialog(); } }

        public string amountString { get { return this.AmountBox.Text; } }

        public string percentString { get { return this.PercentBox.Text; } }

        public bool Capitalization { get { return (bool)this.CapCheck.IsChecked; } }

        public string ITitle { get { return this.Title; } set { this.Title = value; } }

        public Brush AccAmountCol { get { return AmountBox.Background; } set { AmountBox.Background = value; } }

        public Brush AccPercentCol { get { return PercentBox.Background; } set { PercentBox.Background = value; } }

        public void ShowCheckBox()
        {
            this.CapCheck.Visibility = Visibility.Visible;
        }
        public void HideCheckBox()
        {
            this.CapCheck.Visibility = Visibility.Hidden;
        }

        public AddAcount()
        {
            InitializeComponent();
            AddAccountHandler.AccW = this;

            this.cancelBtn.Click += delegate { this.DialogResult = false; };
            this.okBtn.Click += delegate { this.DialogResult = !false; };
            this.AmountBox.TextChanged += delegate { AddAccountHandler.amountParser(); };
            this.PercentBox.TextChanged += delegate { AddAccountHandler.percentParser(); };
            //this.CapCheck.Visibility = Visibility.Hidden;
        }

        static class AddAccountHandler
        {
            public static IAddAccount AccW { get; set; }

            public static void amountParser()
            {
                try
                {
                    decimal Amount = decimal.Parse(AccW.amountString);
                    if (Amount <= 0) throw new ArgumentOutOfRangeException();
                    AccW.AccAmountCol = Brushes.LightGreen;
                }
                catch(FormatException)
                {
                    AccW.AccAmountCol = Brushes.IndianRed;
                }
                catch(ArgumentOutOfRangeException)
                {
                    AccW.AccAmountCol = Brushes.IndianRed;
                }
            }

            public static void percentParser()
            {
                try
                {
                    int.Parse(AccW.percentString);
                    AccW.AccPercentCol = Brushes.LightGreen;
                }
                catch
                {
                    AccW.AccPercentCol = Brushes.IndianRed;
                }
            }
        }
    }
}
