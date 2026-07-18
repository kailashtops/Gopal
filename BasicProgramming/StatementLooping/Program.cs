using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatementLooping
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Switch statement
            Console.WriteLine("Enter a number between 1 and 5:");
            int number = Convert.ToInt32(Console.ReadLine());
            /*  switch(number)
              {
                  case 1:
                      Console.WriteLine("You entered one.");
                      break;
                  case 2:
                      Console.WriteLine("You entered two.");
                      break;
                  case 3:
                  case 4:
                      Console.WriteLine("You entered three or four.");
                      break;
                  case 5:
                      Console.WriteLine("You entered five.");
                      break;
                  default:
                      Console.WriteLine("You entered a number outside the range of 1 to 5.");
                      break;
              }
             if (number == 1)
             {
                 Console.WriteLine("You entered one.");
             }
             else if (number == 2)
             {
                 Console.WriteLine("You entered two.");
             }
             else if (number == 3 || number == 4)
             {
                 Console.WriteLine("You entered three or four.");
             }
             else if (number == 5)
             {
                 Console.WriteLine("You entered five.");
             }
             else { 
               Console.WriteLine("You entered a number outside the range of 1 to 5.");
             }
            while (number < 10)
            {
                 Console.WriteLine("Value of I" + number);
                 number++;
            }
            do {
                Console.WriteLine("value of I is -" + number);
                number++;
            }
            while (number < 10);*/
            Console.ReadLine();
        }
    }
}
