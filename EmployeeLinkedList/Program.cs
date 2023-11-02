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

            var List = new Company();

            foreach (var employee in employeeslist)
            {
                List.Add(employee);
            }

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
                Console.WriteLine("7: View Department List");
                Console.WriteLine("8: Quit Program");

                char sInput = Console.ReadKey().KeyChar; // Reading user input
                Console.WriteLine("\n");

                switch (sInput) // Option selected based on user input
                {
                    case '1': // Views Total Employee List
                        List.PrintFullEmployeeList();
                        break;
                    case '2': // Searches for and displays an employee
                        Node SearchedEmployee = List.SearchForEmployee();
                        if (SearchedEmployee != null)
                        {
                            List.DisplayEmployeeData(SearchedEmployee);
                        }
                        break;
                    case '3': // Adds an employee
                        Console.WriteLine("Input the new employee's First Name: (ex: Bob)");
                        string newFirst = Console.ReadLine();
                        Console.WriteLine("Input the new employee's Last Name: (ex: Dave)");
                        string newLast = Console.ReadLine();
                        Console.WriteLine("Input their Gender: (ex: M)");
                        string newGender = Console.ReadLine();
                        Console.WriteLine("Input their Salary: (ex: 1234.56)");
                        float newSalary = -1;
                        if (float.TryParse(Console.ReadLine(), out float floatValue))
                        {
                            newSalary = floatValue; // Parses user input into a float
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid float.");
                            break;
                        }
                        Console.WriteLine("Input their Department: (ex: FINANCE)");
                        string newDepartment = Console.ReadLine();
                        if (newLast != "" && newFirst != ""
                            && newGender != "" && newSalary >= 0
                            && newDepartment != "") // Checks if user inputted nothing for one of the entries
                        {
                            string newFull = newFirst + " " + newLast;
                            Employee NewEmployee = new Employee();
                            NewEmployee.Name = newFull;
                            NewEmployee.Gender = newGender;
                            NewEmployee.Salary = newSalary.ToString("C");
                            NewEmployee.Department = newDepartment.ToUpper();
                            List.Add(NewEmployee);
                        }
                        else
                        {
                            Console.WriteLine("Error: An incorrect value was entered");
                        }
                        break;
                    case '4': // Views Average Salary of all Employees
                        List.GetAverageSalary();
                        break;
                    case '5': // Edits an Employee
                        Console.WriteLine("Search for the employee you would like to edit:");
                        Node FoundEmployee = List.SearchForEmployee();
                        if (FoundEmployee != null)
                        {
                            List.DisplayEmployeeData(FoundEmployee);
                            List.EditEmployee(FoundEmployee);
                        }
                        break;
                    case '6': // Deletes an Employee
                        Console.WriteLine("Input the desired employee's full name: (ex: Dave Bob) ");
                        string deleteInput = Console.ReadLine();
                        if (List.Delete(deleteInput))
                        {
                            Console.WriteLine("Deleted: " + deleteInput);
                        }
                        break;
                    case '7': // Displays department list
                        List.PrintDepartments();
                        break;
                    case '8': // Quits the program
                        Looper = false;
                        Console.WriteLine("Thank you for using the EmployeeLinkedList program. Goodbye.");
                        break;
                    default:
                        Console.WriteLine("Incorrect option, try again.");
                        break;
                }
            }
        }
    }
}