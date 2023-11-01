using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLinkedList
{
    public class Node
    {
        private Employee _employee;

        // Stores the employee's full name as a string
        public string NameData;
        // Stores the employee's separated name into first and last
        public string FirstName;
        public string LastName;
        public string Gender;
        // Stores the employee's salary as a string
        public string SalaryData;
        // Stores the employee's converted salary as a float
        public float  Salary;
        public string Department;

        public Node Next;
        public Node Previous;
        public Node() { }
        public Node(Employee employee)
        {
            NameData = employee.Name;
            SalaryData= employee.Salary;
            GetName();
            GetSalary();
            Gender = employee.Gender;
            Department = employee.Department;
            _employee = employee;
        }
        public Node(Employee employee, Node next)
        {
            NameData = employee.Name;
            SalaryData = employee.Salary;
            GetName();
            GetSalary();
            Gender = employee.Gender;
            Department = employee.Department;
            _employee = employee;
            Next = next;
        }
        public Node(Employee employee, Node next, Node previous)
        {
            NameData = employee.Name;
            SalaryData = employee.Salary;
            GetName();
            GetSalary();
            Gender = employee.Gender;
            Department = employee.Department;
            _employee = employee;
            Next = next;
            Previous = previous;
        }

        public void GetName()
        // This function splits the employee's full name into first and last parts
        {
            string[] NameParts = NameData.Split(' ');

            if (NameParts.Length >= 2)
            {
                FirstName = NameParts[0];
                LastName = string.Join(" ", NameParts, 1, NameParts.Length - 1);
            }
        }

        public void GetSalary()
        // This function converts the employee's salary from a string to a float
        {
            string CleanSalary = SalaryData.Replace("$", "").Replace(",", "");
            if (float.TryParse(CleanSalary, NumberStyles.Float, CultureInfo.InvariantCulture, out float s))
            {
                Salary = s;
            }
            else
            {
                Console.WriteLine("Error parsing employee salary.");
            }
        }
    }
}
