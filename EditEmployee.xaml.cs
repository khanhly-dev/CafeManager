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
    /// Interaction logic for EditEmployee.xaml
    /// </summary>
    public partial class EditEmployee : Window
    {
        public EditEmployee()
        {
            InitializeComponent();
            this.DataContext = this;
            EditEmployee_LV.ItemsSource = ListEmployee.itemListEm.employees;
        }

        private void OKEdit_BTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CancelEdit_BTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
