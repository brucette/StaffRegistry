using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace StaffRegistry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //bool keepEntering = true;
            //while (keepEntering) 
            //{
            //    Console.WriteLine("Enter first name: ");
            //}

            Console.WriteLine("Enter first name: ");
            string fname = Console.ReadLine()!;

            Console.WriteLine("Enter last name: ");
            string lname = Console.ReadLine()!;

            Console.WriteLine("Enter salary: ");
            int monthSal = int.Parse(Console.ReadLine()!);

            Employee enteredEmp = new Employee(fname, lname, monthSal);

            Database registry = new Database();

            registry.AddEmployee(enteredEmp);
            registry.ShowEmployees();

            //Console.WriteLine("{0} {1} {2}", fname, lname, monthSal);
           
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
