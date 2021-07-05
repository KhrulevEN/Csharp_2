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

namespace EmployeeDepartment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EmployeeDatabase databaseEmployee = new EmployeeDatabase();


        public MainWindow()
        {
            InitializeComponent();
            lvEmployee.ItemsSource = databaseEmployee.Employees;
            cmbDeparment.ItemsSource = databaseEmployee.databaseDepartment.Departments;
        }

        private void lvEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count !=0)
            {
                Employee employee = (Data.Employee)e.AddedItems[0];
                employeeControl.SetEmployee(employee);
                cmbDeparment.SelectedIndex = cmbDeparment.Items.IndexOf((object)employee.Department);
            }
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            if (lvEmployee.SelectedItems.Count < 1)
                return;
            employeeControl.UpdateEmployee((string)cmbDeparment.Items.CurrentItem);
            UpdateBinding();
        }

        private void UpdateBinding()
        {
            lvEmployee.ItemsSource = null;
            lvEmployee.ItemsSource = databaseEmployee.Employees;
            cmbDeparment.ItemsSource = null;
            cmbDeparment.ItemsSource = databaseEmployee.databaseDepartment.Departments;
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lvEmployee.SelectedItems.Count < 1)
                return;
            if (MessageBox.Show("Вы действительно хотите удалить работника?","Удаление работника",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                databaseEmployee.Employees.Remove((Employee)lvEmployee.SelectedItems[0]);
                UpdateBinding();
            }
        }

        private void btnAddDepartment_Click(object sender, RoutedEventArgs e)
        {
            //
            DeparmentEditor dep_editor = new DeparmentEditor();
            if (dep_editor.Execute(databaseEmployee.databaseDepartment.Departments) ==true)
            {
                databaseEmployee.databaseDepartment.Departments.Add(dep_editor.deparment);
                UpdateBinding();
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            EmployeeEditor emp_editor = new EmployeeEditor(databaseEmployee.databaseDepartment.Departments);
            if (emp_editor.ShowDialog() == true)
            {
                databaseEmployee.Employees.Add(emp_editor.Employee);
                UpdateBinding();
            }
        }

    }
}
