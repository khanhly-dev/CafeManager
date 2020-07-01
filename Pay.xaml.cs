using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Cafe_Manager
{
    /// <summary>
    /// Interaction logic for Pay.xaml
    /// </summary>
    public partial class Pay : Window, InotiyPropertyChanged
    {
        #region //event propertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string newname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(newname));
            }
        }
        #endregion

        #region //xu ly thanh toan
        public DateTime timeNow = DateTime.Now;
        public static Pay payInstance = new Pay();
        private Pay()
        {
            InitializeComponent();
            ImportInfoIntoRevenue();
            this.DataContext = this;          
            PayBill_LV.ItemsSource = CafeManager.Instance.bill;
            SumBill();
            Date_TBX.Text = timeNow.Day.ToString() + "/" + timeNow.Month.ToString() + "/" + timeNow.Year.ToString();
            Time_TBX.Text = timeNow.Hour.ToString() + ":" + timeNow.Minute.ToString();
        }
        private int sumTemp = 0;

        public int discount;
        public void SumBill()
        {
            foreach (Food item in CafeManager.Instance.bill)
            {
                sumTemp += item.sumPay;
            }
            SumPay_TB.Text = sumTemp.ToString();
        }

        public void Discount()
        {
            sumTemp = 0;
            if (Discount_TBX.Text != "")
            {
                discount = Convert.ToInt32(Discount_TBX.Text);
                sumTemp -= discount;
                SumBill();
            }
            if (Pay_TBX.Text != "")
            {
                int pay = Convert.ToInt32(Pay_TBX.Text);
                int monneyReturn = pay - sumTemp;
                MoneyReturn_TB.Text = monneyReturn.ToString();
            }
        }

        private void Discount_TBX_TextChanged(object sender, TextChangedEventArgs e)
        {
            Discount();
        }

        private void Pay_TBX_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Pay_TBX.Text != "")
            {
                int pay = Convert.ToInt32(Pay_TBX.Text);
                int monneyReturn = pay - sumTemp;
                MoneyReturn_TB.Text = monneyReturn.ToString();
            }
        }
        #endregion

        public int SumUp = 0;
        private void Pay_BTN_Click(object sender, RoutedEventArgs e)
        {
            foreach (Food item in CafeManager.Instance.bill)
            {
                SumUp += item.sumPay;
            }
            BindingDataToRevenue();          
            this.Close();           
            CafeManager.Instance.bill.Clear(); 
        }

        public class ViewRevenue
        {
            public string foodName { get; set; }
            public int sellNumberic { get; set; }
            public int money { get; set; }
        }
        public ObservableCollection<ViewRevenue> viewRevenues = new ObservableCollection<ViewRevenue>();
        public void ImportInfoIntoRevenue()
        {
            foreach (Food item in CafeManager.Instance.newFood)
            {
                ViewRevenue revenue = new ViewRevenue();
                revenue.foodName = item.foodName;
                revenue.sellNumberic = 0;
                revenue.money = revenue.sellNumberic * item.price;                
                viewRevenues.Add(revenue);                              
            }
        }

        public void BindingDataToRevenue()
        {
            foreach (ViewRevenue item in viewRevenues)
            {
                foreach (Food item1 in CafeManager.Instance.bill)
                {
                    if (item.foodName == item1.foodName)
                    {
                        item.sellNumberic += item1.amount;
                        item.money = item.sellNumberic * item1.price;
                    }
                }
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
    }
}
