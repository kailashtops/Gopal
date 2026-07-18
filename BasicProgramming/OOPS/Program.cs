using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    //Object Oriented Programming System
    //POP procedure oriented programming
    public class StudentList { 
      public string Name { get; set; }
      public string GetName() {
            return Name;
        }
    }
    public class Result { 
     public string Grade { get; set; }
     public int GujratitMarks { get; set; }
     public int ScienceMArks { get; set; }
        public string CalculateResult(int sce, int guj)
        {
            if(sce >= 35 && guj >= 35)
            {
                Grade = "Pass";
            }
            else
            {
                Grade = "Fail";
            }
            return Grade;
        }
    }


    public class Program
    {
        static void Main(string[] args)
        {
            StudentList studentList = new StudentList(); // Instance of StudentList class
            Result result = new Result();
            Console.WriteLine("Enter the Student Name");
            studentList.Name = Console.ReadLine();
           
            Console.WriteLine("Enter the Gujariti Marks");
            result.GujratitMarks = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Enter the Science Marks");
            result.ScienceMArks =  Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Student Name: " + studentList.GetName());
            Console.WriteLine("John Doe Result is :" + result.CalculateResult(result.ScienceMArks, result.GujratitMarks));
            Console.Read();
        }
    }
}
