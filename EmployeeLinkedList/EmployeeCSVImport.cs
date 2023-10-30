using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace EmployeeLinkedList
{
    public class EmployeeCSVImport
    {
        // Reads the data from the csv file
        public List<Employee> ImportEmployees(string csvFilePath)
        {
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                // Read and parse the CSV file into a list of Employee objects
                var employees = csv.GetRecords<Employee>().ToList();
                return employees;
            }
        }
    }
}
