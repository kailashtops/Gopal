using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BasicProgramming
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //Console.Write("Write only");
            //string name = Console.ReadLine();

            //int name = Console.Read(); //return first char default in ascee value

            /*char name = Convert.ToChar(Console.Read()); //return first char default in ascee value
            ConsoleKeyInfo consoleKeyInfo =  Console.ReadKey(); //wait for user input and return the char value
            Console.WriteLine("You entered: " + consoleKeyInfo.KeyChar);
            Console.WriteLine("You entered: " + consoleKeyInfo.Key);
            Console.WriteLine("Hello, " + name + "!");
            Console.ReadLine();*/

            /*int i = 15, j=8;
            if (i <= 10)
            {
                if (j == 5)
                {
                    Console.WriteLine("i is less than or equal to 10 and j is equal to 5");
                }
                else { 
                 Console.WriteLine("i is less than or equal to 10 and j is not equal to 5");
                }
                Console.WriteLine("i is equal to 10");
            }
            else { 
             Console.WriteLine("i is not equal to 10");
            }
            */

            int x , y;
            for (x=0 ,y=10; x < y; x++,y--)
            {
              Console.WriteLine("x: " + x + " y: " + y);
            }
            Console.ReadLine();

            for (int i = 1; i < 10; i++)
            {
                if(i == 5)
                {
                    goto label; //jump to label
                                // break; //exit the loop when i is equal to 5
                                //continue; //skip the rest of the code and move to next iteration
                }
                Console.WriteLine("Hello, World! " + i);
            }
            label:
            Console.WriteLine("Jumped to label");

        }
    }
}

