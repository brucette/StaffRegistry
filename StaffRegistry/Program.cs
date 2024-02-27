using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

// Klasser: Employee, Database
// Attribut på Employee: firstName, lastName, salary - metoder på Employee: PrintEmployeeDetails()
// Attribut på Database: employees array för att lagra personelluppgifterna - metoder på Database: AddEmployee(), ShowEmployees()


namespace StaffRegistry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database registry = new Database();

            string choice = "y"; 

            while (choice == "y")
            {
                Console.WriteLine();
                Console.WriteLine("Enter first name: ");
                string fname = Console.ReadLine()!;

                Console.WriteLine("Enter last name: ");
                string lname = Console.ReadLine()!;

                Console.WriteLine("Enter salary: ");
                int monthSal = int.Parse(Console.ReadLine()!);

                Employee enteredEmp = new Employee(fname, lname, monthSal);

                registry.AddEmployee(enteredEmp);

                Console.WriteLine("Continue (y/n): ");
                choice = Console.ReadLine();
            }
            registry.ShowEmployees();
        }
    }

    public class Employee
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int salary { get; set; }

        public Employee(string firstName, string lastName, int salary)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.salary = salary;
        }
    
        public static void PrintEmployeeDetails(Employee employee)
        {
            Console.WriteLine("{0} {1} {2}", employee.firstName, employee.lastName, employee.salary.ToString());
        }
    }

    public class Database
    {
        public Employee[] employees = Array.Empty<Employee>();

        public void AddEmployee(Employee employee)
        {
            employees = employees.Append(employee).ToArray();
        }

        public void ShowEmployees()
        {
            foreach (Employee employee in employees)
            {
                Employee.PrintEmployeeDetails(employee);
            }
        }
    }
}
