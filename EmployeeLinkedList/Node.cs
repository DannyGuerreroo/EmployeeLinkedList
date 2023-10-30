using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLinkedList
{
    public class Node
    {
        private Employee _employee;

        public string Data;
        public Node Next;
        public Node Previous;
        public Node() { }
        public Node(Employee employee)
        {
            Data = employee.Name;
            _employee = employee;
        }
        public Node(Employee employee, Node next)
        {
            Data = employee.Name;
            _employee = employee;
            Next = next;
        }
        public Node(Employee employee, Node next, Node previous)
        {
            Data = employee.Name;
            _employee = employee;
            Next = next;
            Previous = previous;
        }


    }
}
