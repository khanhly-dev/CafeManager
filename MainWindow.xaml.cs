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

namespace Cafe_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string userName;
        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                CafeManager.Instance.SaveNameManager = userName;
            }
        }
        private string passWord;
        public string PassWord { get => passWord; set => passWord = value; }

        public struct user
        {
            public string UserName;
            public string PassWord;

        }
        List<user> listUser;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = UserName;           
        }

        private void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
            listUser = new List<user>();

            listUser.Add(new user { UserName = "leduykhanh", PassWord = "khanhle1234" });
            listUser.Add(new user { UserName = "1", PassWord = "1" });
            bool dangNhapThanhCong = false;

            foreach (user item in listUser)
            {
                if (loginTXB.Text == item.UserName && passBox.Password == item.PassWord)
                {                  
                    CafeManager.Instance.saveNameManager = item.UserName;
                    this.Hide();
                    CafeManager.Instance.ShowDialog();
                    this.Show();
                    dangNhapThanhCong = true;
                }
            }
            if (!dangNhapThanhCong)
            {
                MessageBox.Show("sai tên đăng nhập hoặc mật khẩu");
            }         
        }

        private void ExitBTN_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }


    }
}
