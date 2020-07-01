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
    /// Interaction logic for AddMenu.xaml
    /// </summary>
    public partial class AddMenu : Window, InotiyPropertyChanged
    {
        //event propertyChange
        #region
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string newname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(newname));
            }
        }
        #endregion

        ObservableCollection<Food> addFoodIntoMenus;

        public AddMenu()
        {
            InitializeComponent();
            addFoodIntoMenus = new ObservableCollection<Food>();  
            AddFoodIntoMenu_LV.ItemsSource = addFoodIntoMenus;
            this.DataContext = this;
        }
  

        private void CancelAdd_BTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddFoodIntoMenu_BTN_Click(object sender, RoutedEventArgs e)
        {
            Food addFoodMenu = new Food {foodName="", price=0 };
            addFoodIntoMenus.Add(addFoodMenu);
            AddFoodIntoMenu_LV.ItemsSource = addFoodIntoMenus;          
        }

        private void OkAdd_BTN_Click(object sender, RoutedEventArgs e)
        {
            foreach (Food item in addFoodIntoMenus)
            {
                CafeManager.Instance.newFood.Add(new Food { foodName = item.foodName, price = item.price });
                this.Close();
            }
        }
    }
}
