using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    public class Employee
    {
        public string emplayeeName { get; set; }
        public string birthday { get; set; }
        public int age { get; set; }
        public string adress { get; set; }
        public string position { get; set; }
        public int salary { get; set; }
        public int support { get; set; }
        public string note { get; set; }
    }
    /// <summary>
    /// Interaction logic for ListEmployee.xaml
    /// </summary>
    public partial class ListEmployee : Window
    {
        public static ListEmployee itemListEm = new ListEmployee();
        private ListEmployee()
        {          
            InitializeComponent();
            DataEmployees(employees);
            ListEmployee_LV.ItemsSource = employees;
        }   

        public ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

        public void DataEmployees(ObservableCollection<Employee> employees)
        {
            employees.Add(new Employee { emplayeeName = "nguyễn văn A", birthday = "23/10/1998", age = 20, adress = "Hà Nội", position = "Thu ngân", salary = 25, support = 0, note = "25k/1h" });
            employees.Add(new Employee { emplayeeName = "nguyễn văn B", birthday = "23/10/1998", age = 20, adress = "Hà Nội", position = "bán hàng", salary = 20, support = 0, note = "25k/1h" });
            employees.Add(new Employee { emplayeeName = "nguyễn văn C", birthday = "23/10/1998", age = 20, adress = "Hà Nội", position = "phục vụ", salary = 20, support = 0, note = "25k/1h" });
            employees.Add(new Employee { emplayeeName = "nguyễn văn D", birthday = "23/10/1998", age = 20, adress = "Hà Nội", position = "nv vệ sinh", salary = 15, support = 0, note = "25k/1h" });
        }

        private void AddEmployee_BTN_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        private void RemoveEmployee_BTN_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = ListEmployee_LV.SelectedItem as Employee;
            employees.Remove(employee);
        }

        private void EditEmployee_BTN_Click(object sender, RoutedEventArgs e)
        {
            EditEmployee editEmployee = new EditEmployee();
            editEmployee.Show();
        }
    }
}
