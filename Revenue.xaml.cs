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
using System.Windows.Shapes;

namespace Cafe_Manager
{
    /// <summary>
    /// Interaction logic for Revenue.xaml
    /// </summary>
    public partial class Revenue : Window
    {       
        public Revenue()
        {
            InitializeComponent();
            this.DataContext = this;
            Revenue_LV.ItemsSource = Pay.payInstance.viewRevenues;
            SumUp();
        }   
        
        public void SumUp()
        {
            Money_Txb.Text = Pay.payInstance.SumUp.ToString();
        }

        private void SpendText_BTN_Click(object sender, RoutedEventArgs e)
        {
            SpendNote spendNote = new SpendNote();
            spendNote.Show();
        }
    }
}
