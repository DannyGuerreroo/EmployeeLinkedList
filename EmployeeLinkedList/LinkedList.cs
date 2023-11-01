using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLinkedList
{
    internal class LinkedList
    {
        private Node _head = null;
        private Node _tail = null;
        private Node _guh = null;

        public void Add(Employee input)
        // Adds an employee to the linked list
        {
            // If it's an empty list, adds the head
            if (_head == null)
            {
                _head = new Node(input);
                _tail = _head;
                return;
            }
            else
            {
                _guh = new Node(input);

                // If input is less than the head, adds a new head
                if (_head.NameData.CompareTo(input.Name) >= 0)
                {
                    Node oldHead = _head;
                    Node newHead = new(input, oldHead);
                    oldHead.Previous = newHead;
                    _head = newHead;
                    return;
                }
            }

            Node current = _head;

            while (current != null)
            {
                // If current is greater than the input:
                if (current.NameData.CompareTo(input.Name) > 0)
                {
                    Node oldCurrent = current;
                    Node newCurrent = new(input);
                    newCurrent.Next = oldCurrent;
                    oldCurrent.Previous = newCurrent;
                    return;
                }
                else
                // If current is less than the input:
                {
                    // If current is the end of the list:
                    if (current.Next == null)
                    {
                        Node newNode = new Node(input, null, current);
                        _tail = newNode;
                        current.Next = newNode;
                        return;
                    }
                    // If the input is less than next
                    if (current.Next.LastName.CompareTo(input.Name) > 0)
                    {
                        Node oldNext = current.Next;
                        current.Next = new Node(input, oldNext, oldNext.Previous);
                        return;
                    }
                }
                current = current.Next;
            }
            return;
        }

        public Node Find(string input)
        // Returns a specified employee
        {
            Node current = _head;

            while (current != null)
            {
                if (current.LastName == input)
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }

        public bool Delete(string input)
        // Deletes the specified employee from the linked list
        {
            Node target = Find(input);
            if (target == null)
            {
                return false;
            }
            else if (target == _head)
            {
                if (_head.Next == null)
                {
                    _head = null;
                    _tail = null;
                }
                else
                {
                    _head = _head.Next;
                    _head.Previous = null;
                }
            }
            else if (target == _tail)
            {
                _tail = target.Previous;
                _tail.Next = null;
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
                Console.WriteLine(current.FirstName + ", " + current.LastName
                    + " - " + current.Gender
                    + " " + current.Salary.ToString("C")
                    + " " + current.Department);
                current = current.Next;
            }
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
    }
}
