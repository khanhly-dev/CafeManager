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
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        public AddEmployee()
        {
            InitializeComponent();
            this.DataContext = this;

        }

        private void CancelAdd_BTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public ObservableCollection<Employee> addEmployee = new ObservableCollection<Employee>();

        private void AddEmployeeIntoList_BTN_Click(object sender, RoutedEventArgs e)
        {
            Employee addEm = new Employee();
            addEmployee.Add(addEm);
            AddEmployee_LV.ItemsSource = addEmployee;
        }

        private void OkAdd_BTN_Click(object sender, RoutedEventArgs e)
        {
            
            foreach (Employee item in addEmployee)
            {
                ListEmployee.itemListEm.employees.Add(new Employee { adress = item.adress, age = item.age, birthday = item.birthday, emplayeeName = item.emplayeeName, note = item.note, position = item.position, salary = item.salary, support = item.support });
            }
            this.Close();
        }
    }
}
