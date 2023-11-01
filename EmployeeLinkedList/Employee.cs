using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLinkedList
{
    public class Employee
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Salary { get; set; }
        public string Department { get; set; }

        //public string FirstName
        //{
        //    get
        //    {

        //            string[] parts = Name.Split(' ');
        //            if (parts.Length > 0)
        //            {
        //                return parts[0];
        //            }
                
        //        return null; // Handle the case where the Name is empty or doesn't contain a space.
        //    }
        //}
        //public string LastName
        //{
        //    get
        //    {

        //            string[] parts = Name.Split(' ');
        //            if (parts.Length > 1)
        //            {
        //                return string.Join(" ", parts.Skip(1));
        //            }
        //        return null; // Handle the case where the Name is empty, doesn't contain a space, or has only one name.
        //    }
        //}

    }
}
