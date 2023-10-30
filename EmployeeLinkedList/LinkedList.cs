using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLinkedList
{
    internal class LinkedList
    {
        private Node _head = null;
        private Node _tail = null;

        public void Add(Employee input)
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
                // If input is less than the head, adds a new head
                if (_head.Data.CompareTo(input.Name) >= 0)
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
                if (current.Data.CompareTo(input.Name) > 0)
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
                    if (current.Next.Data.CompareTo(input.Name) > 0)
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

        public Node Find(Employee input)
        {
            Node current = _head;

            while (current != null)
            {
                if (current.Data == input.Name)
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }
    }
}
