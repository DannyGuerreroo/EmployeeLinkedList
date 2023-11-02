using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployeeLinkedList
{
    public class Company
    {
        private Node _head = null;
        private Node _cemployee = null;

        public List<string> departmentList = new List<string>();

        public void Add(Employee input)
        {
            AddDepartment(departmentList, input.Department);
            Node newNode = new Node(input);
            _cemployee = new Node(input);

            // If it's an empty list, add the head
            if (_head == null)
            {
                _head = newNode;
                return;
            }

            Node current = _head;
            Node previous = null;

            while (current != null)
            {
                // Compares the last names
                if (current.LastName.ToLower().CompareTo(_cemployee.LastName.ToLower()) == 0)
                // If last names are the same, compares the first names
                {
                    if (current.FirstName.ToLower().CompareTo(_cemployee.FirstName.ToLower()) > 0)
                    {
                        // Insert before the current node
                        newNode.Next = current;
                        newNode.Previous = current.Previous;
                        current.Previous = newNode;

                        if (previous != null)
                        {
                            previous.Next = newNode;
                        }
                        else
                        {
                            _head = newNode; // Updates the head if necessary
                        }

                        return;
                    }
                }
                else if (current.LastName.ToLower().CompareTo(_cemployee.LastName.ToLower()) > 0)
                {
                    // Insert before the current node
                    newNode.Next = current;
                    newNode.Previous = current.Previous;
                    current.Previous = newNode;

                    if (previous != null)
                    {
                        previous.Next = newNode;
                    }
                    else
                    {
                        _head = newNode; // Update the head if necessary
                    }

                    return;
                }

                previous = current;
                current = current.Next;
            }

            // If the end is reached, add the new node at the end
            previous.Next = newNode;
            newNode.Previous = previous;
        }

        public enum SearchType // A search type to make efficient searches
        {
            FirstName,
            LastName,
            Department,
            FullName
        }

        public Node Find(string input, SearchType searchType)
        // Returns a specified employee
        {
            Node current = _head;

            while (current != null)
            {
                // Will keep looping to find the specified string in that search type
                bool MatchFound = false; // Bool used to know when the match is found
                switch (searchType)
                {
                    case SearchType.FirstName:
                        MatchFound = string.Equals(current.FirstName, input, StringComparison.OrdinalIgnoreCase); // Case insensitive checks
                        break;
                    case SearchType.LastName:
                        MatchFound = string.Equals(current.LastName, input, StringComparison.OrdinalIgnoreCase);
                        break;
                    case SearchType.Department:
                        MatchFound = string.Equals(current.Department, input, StringComparison.OrdinalIgnoreCase);
                        break;
                    case SearchType.FullName:
                        MatchFound = string.Equals(current.NameData, input, StringComparison.OrdinalIgnoreCase);
                        break;
                    default:
                        Console.WriteLine("Invalid search type.");
                        return null;
                }
                if (MatchFound) // If match is found, returns that Node
                {
                    return current;
                }
                current = current.Next;
            }
            Console.WriteLine("Employee not found.");
            return null;
        }

        public bool Delete(string input)
        // Deletes the specified employee from the linked list
        {
            Node target = Find(input, SearchType.FullName);
            if (target == null)
            {
                return false;
            }
            else if (target == _head) // edge case for head
            {
                if (_head.Next == null)
                {
                    _head = null;
                }
                else
                {
                    _head = _head.Next;
                    _head.Previous = null;
                }
            }
            else
            {
                target.Previous.Next = target.Next;
            }
            return true;
        }

        public void PrintFullEmployeeList()
        // Prints a list of the employees in the linked list
        {
            Node current = _head;
            while (current != null )
            {
                Console.WriteLine(current.LastName + ", " + current.FirstName
                    + " - " + current.Gender
                    + ", " + current.Salary.ToString("C")
                    + ", " + current.Department);
                current = current.Next;
            } // Display employee data function doesn't work here for some reason
        }

        public void GetAverageSalary()
        {
            Node current = _head;

            if (current != null) 
            {
                float CombinedSalary = 0;
                float NumberOfEmployees = 0;
                // Adds up each employee's salary and then averages them
                while (current != null)
                {
                    CombinedSalary += current.Salary;
                    NumberOfEmployees++;
                    current = current.Next;
                }
                CombinedSalary = CombinedSalary / NumberOfEmployees; // Averaged
                Console.WriteLine("Average Salary of all Employees: " + CombinedSalary.ToString("C"));
            }
            else // In case there are no employees in the list
            {
                Console.WriteLine("No employees in list.");
            }
        }

        public void DisplayEmployeeData(Node input) // Display employee data function
        {
            Console.WriteLine(input.NameData + " - " + input.Gender
                + ", " + input.Salary.ToString("C") + ", " + input.Department);
        }

        public Node SearchForEmployee() // Function to efficiently search for a specific employee
        {
            bool searchLooper = true;
            while (searchLooper == true) // A loop so user can keep selecting options
            {
                Console.WriteLine("Search by Last Name, First Name, or Department? (1, 2, or 3)");
                char searchKeyInput = Console.ReadKey().KeyChar;
                Console.WriteLine("\n");

                string searchInput; // Vars to store input and output
                Node searchOutput;

                switch (searchKeyInput)
                {

                    case '1': // Last Name
                        searchLooper = false;
                        Console.WriteLine("Input the desired employee's last name: (ex:Bob) ");
                        searchInput = Console.ReadLine();
                        searchOutput = Find(searchInput, Company.SearchType.LastName);
                        if (searchOutput != null)
                        {
                            return searchOutput;
                        }
                        return null;
                    case '2': // First Name
                        searchLooper = false;
                        Console.WriteLine("Input the desired employee's first name: (ex:Dave) ");
                        searchInput = Console.ReadLine();
                        searchOutput = Find(searchInput, Company.SearchType.FirstName);
                        if (searchOutput != null)
                        {
                            return searchOutput;
                        }
                        return null;
                    case '3': // Department
                        searchLooper = false;
                        Console.WriteLine("Input the desired department name: (ex:FINANCE) ");
                        searchInput = Console.ReadLine();
                        searchOutput = Find(searchInput, Company.SearchType.Department);
                        if (searchOutput != null)
                        {
                            return searchOutput;
                        }
                        return null;
                    default:
                        Console.WriteLine("Incorrect value entered.");
                        return null;
                }
            }
            return null;
        }

        public void EditEmployee(Node input)
        {
            bool editLooper = true;
            while (editLooper == true) // A loop so user can keep selecting options
            {
                Console.WriteLine("Which element of this employee would you like to edit?");
                Console.WriteLine("1 for First Name, 2 for Last Name, 3 for Gender, 4 for Salary, 5 for Department");
                char editKeyInput = Console.ReadKey().KeyChar;
                Console.WriteLine("\n");

                string editInput;

                switch (editKeyInput)
                {
                    case '1': // Edit first name
                        editLooper = false;
                        Console.WriteLine("Input the new first name:");
                        editInput = Console.ReadLine();
                        if (editInput != "")
                        {
                            input.FirstName = editInput;
                            input.NameData = input.FirstName + " " + input.LastName;
                            Employee EditedEmployee = new Employee();
                            EditedEmployee.Name = input.NameData;
                            EditedEmployee.Gender = input.Gender;
                            EditedEmployee.Salary = input.SalaryData;
                            EditedEmployee.Department = input.Department;
                            Delete(input.NameData); // Delete and re-add the employee in order to re-sort
                            Add(EditedEmployee);    // them into the list with their updated data
                        }
                        else
                        {
                            Console.WriteLine("Error: null value entered");
                        }
                        break;
                    case '2': // Edit last name
                        editLooper = false;
                        Console.WriteLine("Input the new last name:");
                        editInput = Console.ReadLine();
                        if (editInput != "")
                        {
                            input.LastName = editInput;
                            input.NameData = input.FirstName + " " + input.LastName;
                            Employee EditedEmployee = new Employee();
                            EditedEmployee.Name = input.NameData;
                            EditedEmployee.Gender = input.Gender;
                            EditedEmployee.Salary = input.SalaryData;
                            EditedEmployee.Department = input.Department;
                            Delete(input.NameData); // Delete and re-add the employee in order to re-sort
                            Add(EditedEmployee);    // them into the list with their updated data
                        }
                        else
                        {
                            Console.WriteLine("Error: null value entered");
                        }
                        break;
                    case '3': // Edit Gender
                        editLooper = false;
                        Console.WriteLine("Input the new gender:");
                        editInput = Console.ReadLine();
                        if (editInput != "")
                        {
                            input.Gender = editInput;
                        }
                        break;
                    case '4': // Edit Salary
                        editLooper = false;
                        Console.WriteLine("Input the new salary: (ex: 1234.56");
                        float newSalary = -1;
                        if (float.TryParse(Console.ReadLine(), out float floatValue))
                        {
                            newSalary = floatValue; // Parses user input into a float
                            input.Salary = newSalary;
                            input.SalaryData = newSalary.ToString("C");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid float.");
                        }
                        break;
                    case '5': // Edit Department
                        editLooper = false;
                        PrintDepartments();
                        Console.WriteLine("Input the new department: (it must be an already existing department)");
                        editInput = Console.ReadLine();
                        if (departmentList.Contains(editInput.ToUpper())) // ToUpper to make it case-insensitive
                        {
                            input.Department = editInput.ToUpper();
                        }
                        else
                        {
                            Console.WriteLine("Incorrect department entered.");
                        }
                        break;
                    default:
                        Console.WriteLine("Incorrect value entered.");
                        break;
                }
            }
        }

        public void AddDepartment(List<string> list, string input) // Adds new departments to the department list
        {
            if (!list.Contains(input))
            {
                list.Add(input.ToUpper()); // Using ToUpper in order to keep the
                                           // department list case-insensitive
            }
        }

        public void PrintDepartments() // Prints list of departments
        {
            foreach (var item in departmentList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
