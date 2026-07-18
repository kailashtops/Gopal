using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstractemp
{
    public sealed class ATMPINP
    {
        public void ValidatePIN()
        {
            Console.WriteLine("Validating ATM PIN...");
        }

        // not accessible outside the class
    }
    public abstract class Employee
    {
        public abstract void CalculateSalary();
        public abstract void DisplayEmployeeDetails();
    }

    public class Program : Employee
    {
        static void Main(string[] args)
        {
           
            Program emp = new Program();
            emp.CalculateSalary();
            Console.Read();
        }

        public override void CalculateSalary()
        {
           Console.WriteLine("Calculating salary for employee...");
        }

        public override void DisplayEmployeeDetails()
        {
           Console.WriteLine("Displaying employee details...");
        }
    }
}
