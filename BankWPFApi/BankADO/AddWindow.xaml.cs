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
using System.Data;

namespace BankADO
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window,IAdd
    {
        public bool IShowDialog { get { return (bool)this.ShowDialog(); } }
        public string fullNameString
        {
            get
            {
                if (third_string_on)
                {
                    return this.nameBox.Text + ' ' + this.lastnameBox.Text;
                }
                else
                {
                    return this.nameBox.Text;
                }
            }
        }
        public string dateString { get { return this.dateBox.Text; } }
        //public string nameString { get { return this.nameBox.Text; } }
        public string nameText { get { return this.nameBlock.Text; } set { this.nameBlock.Text = value; } }
        public string dateText { get { return this.dateBlock.Text; } set { this.dateBlock.Text = value; } }
        public string lastNameText { get { return this.lastnameBlock.Text; } set { this.lastnameBlock.Text = value; } }
        public string ITitle { get { return this.Title; } set { this.Title = value; } }

        public bool third_string_on { get { return this.lastnameBox.IsEnabled; } set { this.lastnameBox.IsEnabled = value; } }

        public Brush CreateBoxCol { get { return dateBox.Background; } set { dateBox.Background = value; } }

        public AddWindow()
        {
            InitializeComponent();
            AddWindowHandler.AW = this;

            this.cancelBtn.Click += delegate { this.DialogResult = false; };
            this.okBtn.Click += delegate { this.DialogResult = !false; };
            this.dateBox.TextChanged += delegate { AddWindowHandler.createDateParser(); };
        }

        //private void DateBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    AddWindowHandler.createDateParser();
        //}
    }

    static class AddWindowHandler
    {
        public static IAdd AW { get; set; }

        public static void createDateParser()
        {
            try
            {
                Convert.ToDateTime(AW.dateString);
                AW.CreateBoxCol = Brushes.LightGreen;
            }
            catch
            {
                AW.CreateBoxCol = Brushes.IndianRed;
            }
        }
    }
}
