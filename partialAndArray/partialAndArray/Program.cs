using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace partialAndArray
{
    public partial class Calculation {

        public void Add(int a, int b)
        {
            Console.WriteLine("Sum: " + (a + b));
        }
    }
    public partial class Calculation
    {

        public void Multiple(int a, int b)
        {
            Console.WriteLine("Sum: " + (a * b));
        }
    }
    public partial class Calculation
    {

        public void Div(int a, int b)
        {
            Console.WriteLine("Sum: " + (a / b));
        }
    }
    public class test {
        private int i;
        public int result;
        protected string subject;
        private void GetNAme()
        {
            Console.WriteLine("Get Name");
        }
        protected void GetSubject()
        {
            Console.WriteLine("Get Subject");
        }
    }

    public class VirtualMethod { 
    
        public void TestMethod()
        {
            Console.WriteLine("Test Method");
        }
        public virtual void VirtualTestMethod()
        {
            Console.WriteLine("Virtual Test Method");
        }
    }

    public class Program: VirtualMethod
    {
        public override void VirtualTestMethod()
        {
            Console.WriteLine("Virtual Test Method in Program class");
        }
        static void Main(string[] args)
        {
            Program virtualMethod = new Program();
            virtualMethod.VirtualTestMethod();
            virtualMethod.TestMethod();

           /* Program objPro = new Program();
            objPro.result = 100;
            objPro.subject = "Maths";
            objPro.GetSubject();
            */


            Calculation calculation = new Calculation();
            calculation.Add(10, 20);
            calculation.Multiple(10, 20);
            calculation.Div(10, 20);
        }
    }
    public class NextLevel:Program { 
      
    }
}
