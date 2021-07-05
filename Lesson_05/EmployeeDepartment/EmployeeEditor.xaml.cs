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
using System.Windows.Shapes;

namespace EmployeeDepartment
{
    /// <summary>
    /// Interaction logic for EmployeeEditor.xaml
    /// </summary>
    public partial class EmployeeEditor : Window
    {

        public EmployeeEditor(List<string> _Departments)
        {
            InitializeComponent();
            cmbDepartment.ItemsSource = _Departments;
            EmployeeControl.SetEmployee(Employee);
        }

        public Employee Employee {get; set;} = new Employee();

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            EmployeeControl.UpdateEmployee((string)cmbDepartment.SelectedItem);
            DialogResult = true;
        }


    }
}
