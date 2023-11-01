using System.ComponentModel.Design;
using System.Reflection;

namespace EmployeeLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Importing the .csv file 
            EmployeeCSVImport import = new EmployeeCSVImport();
            List<Employee> employeeslist = import.ImportEmployees("employees-1.csv");

            var List = new LinkedList();

            foreach (var employee in employeeslist)
            {
                List.Add(employee);
            }

            //List.PrintFullEmployeeList();
            //Console.WriteLine("\n");
            //List.Delete("Wheeler");
            //Console.WriteLine("\n");
            //List.PrintFullEmployeeList();

            bool Looper = true;
            while (Looper == true) // A loop so user can keep selecting options
            {
                Console.WriteLine("\nChoose an option from the following: (Enter the number)");
                Console.WriteLine("1: View Employee List");
                Console.WriteLine("2: Search for and display an employee");
                Console.WriteLine("3: Add an employee");
                Console.WriteLine("4: View Average Salary of all Employees");
                Console.WriteLine("5: Edit an Employee");
                Console.WriteLine("6: Delete an Employee");
                Console.WriteLine("7: Quit Program");

                char sInput = Console.ReadKey().KeyChar; // Reading user input
                Console.WriteLine("\n");

                switch (sInput) // Option selected based on user input
                {
                    case '1': // Views Total Employee List
                        List.PrintFullEmployeeList();
                        break;
                    case '2': // Searches for and displays an employee
                        break;
                    case '3': // Adds an employee
                        Console.WriteLine("");
                        break;
                    case '4': // Views Average Salary of all Employees
                        List.GetAverageSalary();
                        break;
                    case '5': // Edits an Employee
                        break;
                    case '6': // Deletes an Employee
                        Console.WriteLine("Input the desired employee's full name: (ex: Dave Bob) ");
                        string deleteInput = Console.ReadLine();
                        List.Delete(deleteInput);
                        break;
                    case '7': // Quits the program
                        Looper = false;
                        Console.WriteLine("Thank you for using the EmployeeLinkedList program. Goodbye.");
                        break;
                }
            }
        }
    }
}