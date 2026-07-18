using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace overloaddingridding
{
    //Method overlodding method name is same but parameter is different
    //number of parameter or type of parameter is different
    public class Overloadding {
        public int CombineName(int i, int j) {
            return i + j;
          
        }
        public string CombineName(string fname, string lname) { 
          return fname + " " + lname;
        }
        public string CombineName(string fname, string mname, string lname)
        {
            return fname + " " + mname + " " + lname;
        }


    }
    public class OPoverrloading
    {
        int X, Y;
        public OPoverrloading() {
            X = 0;
            Y = 0;
        }
        public OPoverrloading(int i, int j)
        {
            X = i;
            Y = j;
        }
        public static OPoverrloading operator +(OPoverrloading a, OPoverrloading b)
        {
            OPoverrloading result = new OPoverrloading();
            result.X = a.X + b.X;
            result.Y = a.Y + b.Y;
            return result;
        }
        public static OPoverrloading operator ++(OPoverrloading a)
        {
            OPoverrloading result = new OPoverrloading();
            result.X = a.X ++;
            result.Y = a.Y ++;
            return result;
        }
        public void Display()
        {
            Console.WriteLine("X: " + X + " Y: " + Y);
        }

    }


    public class Program
    {
        static void Main(string[] args)
        {
            //1D array
            //Multidimnsion 
            //Jagged array

            int[] arr = new int[5] { 10, 12, 35, 74, 5 }; //collection of similar datatype
            foreach (int i in arr)
            {
               // Console.WriteLine(i);
            }

            int[,] arr1 = new int[2, 3];
            arr1[0, 0] = 10;
            arr1[0, 1] = 20;
            arr1[0, 2] = 33;

            arr1[1, 0] = 17;
            arr1[1, 1] = 20;
            arr1[1, 2] = 30;
            for(int i = 0; i < arr1.GetLength(0); i++)
            {
                for (int j = 0; j < arr1.GetLength(1); j++)
                {
                    Console.Write(arr1[i, j] + " ");
                }
                Console.WriteLine();
            }
            int[][] arr2 = new int[2][];
            arr2[0] = new int[] { 10, 20, 30 };
            arr2[1] = new int[] { 17, 20, 30 };


            //operator overlodding
            OPoverrloading oPoverrloading = new OPoverrloading(5, 10);
            oPoverrloading.Display();
            oPoverrloading = oPoverrloading + new OPoverrloading(15, 20);
            oPoverrloading.Display();
            oPoverrloading = oPoverrloading++;
            oPoverrloading.Display();


            //Method overlodding
            Overloadding overloadding = new Overloadding();
            Console.WriteLine(overloadding.CombineName("John", "Michael", "Doe"));
            Console.WriteLine(overloadding.CombineName(5, 10));
            Console.WriteLine(overloadding.CombineName("John", "Doe"));
           
        }
    }
}
