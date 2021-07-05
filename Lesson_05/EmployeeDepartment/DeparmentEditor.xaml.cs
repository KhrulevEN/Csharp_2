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
    /// Interaction logic for DeparmentEditor.xaml
    /// </summary>
    public partial class DeparmentEditor : Window
    {
        public List<string> Departments;
        public string deparment;

        public DeparmentEditor()
        {
            InitializeComponent();
        }

        public bool Execute(List<string> _Departments)
        {
            Departments = _Departments;
            if (ShowDialog() == true)
            {
                return true;
            }         
            
            return false;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            deparment = txbDepartment.Text;
            if (!Departments.Contains(deparment))
                DialogResult = true;
            else
                MessageBox.Show("Такой департамент уже есть!", "Департамент",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
