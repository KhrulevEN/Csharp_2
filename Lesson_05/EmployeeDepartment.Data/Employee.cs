using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDepartment.Data
{
    public class Employee
    {
        public string Department { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }

        public string FIO
        {
            get { return $"{LastName} {FirstName} {SecondName}"; }
        }

        public Employee() { }

        public Employee(string phone, string firstName, string lastName, string secondName, string department)
        {
            Phone = phone;
            FirstName = firstName;
            LastName = lastName;
            SecondName = secondName;
            Department = department;
        }

        public override string ToString()
        {
            return $"{Phone} - {LastName} {FirstName} {SecondName}";
        }

    }
}
