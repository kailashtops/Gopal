using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valueref
{
    public static class Account { 
     
        
        public static void GetAccountNumber()
        {
            Console.WriteLine("Account number is 12345");
        }

    }
    public class Program
    {
        //static method 
        public static void Getstaticmethod()
        {
            Console.WriteLine("Getstaticmethod");
        }
        //userdefined data type
        enum orderStatus
        {
            Pending,Processing,Skipped,Delivered
        }

        static void Main(string[] args)
        {
            Getstaticmethod();
            Account.GetAccountNumber();


            int pen = (int)orderStatus.Skipped;
            if(pen==3)
            {
                
            Console.WriteLine("Order is being processed"+pen);
            }
            Console.WriteLine(orderStatus.Skipped);
            int a = 10;
            object b =20;
            Console.WriteLine("Before a: {0}, b: {1}", a, b);
            b = (object)a; // boxing

            Console.WriteLine("a: {0}, b: {1}", a, b);
            a = (int)b; // unboxing


           double number = 1250.525;
            int f = (int)number; // implicit conversion

            //1250

            Console.Read();
        }
    }
}
