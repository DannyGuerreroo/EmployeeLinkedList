using System.Reflection;

namespace EmployeeLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            EmployeeCSVImport import = new EmployeeCSVImport();
            List<Employee> employeeslist = import.ImportEmployees("employees.csv");

            foreach (var employee in employeeslist)
            {
                Console.WriteLine($"Name: {employee.Name}, Job Title: {employee.Department}");
            }
        }
    }
}