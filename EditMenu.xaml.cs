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
    /// Interaction logic for EditMenu.xaml
    /// </summary>
    public partial class EditMenu : Window
    {
        public EditMenu()
        {
            InitializeComponent();      
            this.DataContext = this;
            EditFoodFromMenu_LV.ItemsSource = CafeManager.Instance.newFood;
        }
        private void CancelEdit_BTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OKEdit_BTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
