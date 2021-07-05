using EmployeeDepartment.Data;
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

namespace EmployeeDepartment.Controls
{
    /// <summary>
    /// Interaction logic for EmployeeControl.xaml
    /// </summary>
    public partial class EmployeeControl : UserControl
    {
        private Employee employee;

        public EmployeeControl()
        {
            InitializeComponent();
            //cmbDeparment.ItemsSource = databaseDepartment.Departments;
        }

        public void SetEmployee(Employee _employee)
        {
            employee = _employee;
            tbLastName.Text = _employee.LastName;
            tbFirstName.Text = _employee.FirstName;
            tbSecondName.Text = _employee.SecondName;
            tbPhone.Text = _employee.Phone;
            //cmbDeparment.SelectedItem = employee.Department;
        }

        public void UpdateEmployee(string department)
        {
            employee.LastName = tbLastName.Text;
            employee.FirstName = tbFirstName.Text;
            employee.SecondName = tbSecondName.Text;
            employee.Phone = tbPhone.Text;
            employee.Department = department;//(Department)cmbDeparment.SelectedItem;
        }
    }
}
