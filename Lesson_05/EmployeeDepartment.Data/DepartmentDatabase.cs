using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDepartment.Data
{
    public class DepartmentDatabase
    {

        public List<string> Departments { get; set; }

        public DepartmentDatabase()
        {
            Departments = new List<string>();
            GenerateDepartments(8);
        }

        private void GenerateDepartments(int deparmentCount)
        {
            Departments.Clear();
            for (int i = 0; i < deparmentCount; i++)
            {
                Departments.Add((i+1).ToString());
            }
        }
    }
}
