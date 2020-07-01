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
    // class món ăn
    public class Food
    {
        public string foodName { get; set; }
        public int price { get; set; }
        public int amount { get; set; }
        public int sumPay { get; set; }
    } 

    /// <summary>
    /// Interaction logic for CafeManager.xaml
    /// </summary>
    public partial class CafeManager : Window, INotifyPropertyChanged
    {
        // constructor

        public static CafeManager Instance = new CafeManager();
        private CafeManager()
        {
            InitializeComponent();
            this.DataContext = this;
            AddFood();
            AddTable();                   
        }

        // event propertyChange
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
        // xử lý thêm xóa sửa menu
        #region

        public int numbericCount = 0;
        public ObservableCollection<Food> newFood { get; set; }

        private void UpNumber_BTN_Click(object sender, RoutedEventArgs e)
        {
            
            numbericCount += 1;
            Number_TBX.Text = Convert.ToString(numbericCount);
        }

        private void DownNumber_BTN_Click(object sender, RoutedEventArgs e)
        {
            
            numbericCount -= 1;
            Number_TBX.Text = Convert.ToString(numbericCount);
        }      

        public string saveNameManager = "";       
        public string SaveNameManager
        {
            get { return saveNameManager; }
            set
            {
                saveNameManager = value;
                OnPropertyChanged("SaveNameManager");
            }
        }

        private void AddFood()
        {
            newFood = new ObservableCollection<Food>();
            newFood.Add(new Food { foodName = "Sg Cafe", price = 15000 });
            newFood.Add(new Food { foodName = "Sg Cafe Milk", price = 18000 });
            newFood.Add(new Food { foodName = "Espresso (Cafe nóng)", price = 18000 });
            newFood.Add(new Food { foodName = "Cappuccino (Cafe Ý)", price = 25000 });
            newFood.Add(new Food { foodName = "Latte (Cafe tạo hình)", price = 25000 });
            newFood.Add(new Food { foodName = "Coolies'N Cream (Cafe Cookies)", price = 30000 });
            newFood.Add(new Food { foodName = "Blende Coffee Balley (Cafe rượu sữa)", price = 30000 });
            newFood.Add(new Food { foodName = "Kiwi (Sinh tố Kiwi)", price = 25000 });
            newFood.Add(new Food { foodName = "Strawberry (Dâu)", price = 25000 });
            newFood.Add(new Food { foodName = "Blubery (Việt quất)", price =25000});
            newFood.Add(new Food { foodName = "Lychee (Vải)", price = 25000 });
            newFood.Add(new Food { foodName = "Peach (Đào)", price = 28000 });
            newFood.Add(new Food { foodName = "Grapefruit (Bưởi)", price = 28000 });
            newFood.Add(new Food { foodName = "Pineapple (Dứa)", price = 28000 });
            newFood.Add(new Food { foodName = "Orange Mango (Cam xoài)", price = 28000});
            newFood.Add(new Food { foodName = "Kiwi + Lychee (Kiwi + vải)", price = 28000 });
            newFood.Add(new Food { foodName = "Soda Green Mint (Soda bạc hà)", price = 28000 });
            newFood.Add(new Food { foodName = "Soda Grapefruit (Soda bưởi)", price = 28000 });
            newFood.Add(new Food { foodName = "Lemon Yogurt (Chanh)", price = 28000 });
            newFood.Add(new Food { foodName = "Green Tea (Trà xanh)", price = 28000 });
            newFood.Add(new Food { foodName = "Green Mint (Chanh bạc hà)", price = 28000 });
            ListMenu_LV.ItemsSource = newFood;
            ListFood_CB.ItemsSource = newFood;
            ListFood_CB.DisplayMemberPath = "foodName";
        }

        private void ListFood_CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Number_TBX != null)
            {
                numbericCount = 0;
                Number_TBX.Text = "1";
            }
        }

        private void RemoveMenu_BTN_Click(object sender, RoutedEventArgs e)
        {
            Food food = ListMenu_LV.SelectedItem as Food;
            if (food != null)
            {
                newFood.Remove(food);
            }
        }

        private void AddMenu_BTN_Click(object sender, RoutedEventArgs e)
        {
            AddMenu addMenu = new AddMenu();
            addMenu.Show();
        }

        private void EditMenu_BTN_Click(object sender, RoutedEventArgs e)
        {           
            EditMenu editMenu = new EditMenu();
            editMenu.Show();          
        }

        #endregion
        // kết nối danh sách với bàn ăn
        #region
        public class Table
        {
            public int ID { get; set; }
            public string tableName { get; set; }
            public ObservableCollection<Food> listBill = new ObservableCollection<Food>();
        }
        ObservableCollection<Table> listTable = new ObservableCollection<Table>();
        public void AddTable()
        {
            for (int i = 0; i < 10; i++)
            {
                listTable.Add(new Table { ID = i, tableName = "Bàn " + (i+1).ToString()+ " trống" });
            }

            foreach (Table item in listTable)
            {
                Button addTableBTN = new Button();
                Thickness margin = addTableBTN.Margin;
                Thickness padding = addTableBTN.Padding;
                margin.Left = 15;
                margin.Right = 15;
                margin.Top = 15;
                margin.Bottom = 15;
                padding.Top = 0;
                padding.Bottom = 0;
                padding.Left = 0;
                padding.Right = 0;
                addTableBTN.Width = 60;
                addTableBTN.Height = 60;
                addTableBTN.Padding = padding;
                addTableBTN.Margin = margin;
                addTableBTN.Content = item.tableName;
                Table_PN.Children.Add(addTableBTN);
                addTableBTN.Tag = item;
                addTableBTN.Click += TableBTN_Click;
            }
        }

        public void ShowBill(int id)
        {
            ListBill_LV.Items.Clear();
            foreach (Table item in listTable)
            {
                ListBill_LV.ItemsSource = item.listBill;              
            }
        }

        private void TableBTN_Click(object sender, RoutedEventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            ShowBill(tableID);
            Button button = sender as Button;
        }

        #endregion
        // thêm xóa thanh toán bill
        #region
        public ObservableCollection<Food> bill = new ObservableCollection<Food>();

        private void AddBill_BTN_Click(object sender, RoutedEventArgs e)
        {
            Food food = ListFood_CB.SelectedItem as Food;
            food.amount = Convert.ToInt32(Number_TBX.Text);
            food.sumPay = food.price * food.amount;
            bill.Add(food);
            ListBill_LV.ItemsSource = bill;
        }

        private void RemoveBill_BTN_Click(object sender, RoutedEventArgs e)
        {
            Food food = ListBill_LV.SelectedItem as Food;
            bill.Remove(food);
            ListBill_LV.ItemsSource = bill;
        }

        private void PayBill_BTN_Click(object sender, RoutedEventArgs e)
        {
            //Pay payTab = new Pay();
            //payTab.Show();
            Pay.payInstance.Show();
        }
        #endregion

        private void Window_Closed(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        private void ListEmployee_BTN_Click(object sender, RoutedEventArgs e)
        {
            ListEmployee.itemListEm.Show();            
        }

        private void Timesheets_BTN_Click(object sender, RoutedEventArgs e)
        {
            TimeSheets timeSheets = new TimeSheets();
            timeSheets.Show();
        }

        private void revenue_BTN_Click(object sender, RoutedEventArgs e)
        {
            Revenue revenue = new Revenue();
            revenue.Show();
        }
    }
}
