using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

namespace ConsoleApp2
{
    public class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=.;Initial Catalog=testapp;Integrated Security=True;";
            string filePath = @"D:\Temp\test.csv";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var reader = new StreamReader(@"D:\Temp\test.csv"))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true
                }))
                {
                    var records = csv.GetRecords<dynamic>();

                    foreach (var r in records)
                    {
                        using (var cmd = new SqlCommand(
                            @"INSERT INTO Tbl_Question 
              (FKQCategory, Cls, Quersion, OptionA, OptionB, OptionC, OptionD, Answer, IsActive)
              VALUES (@FKQCategory, @Cls, @Quersion, @OptionA, @OptionB, @OptionC, @OptionD, @Answer, @IsActive)", conn))
                        {
                            cmd.Parameters.AddWithValue("@FKQCategory", int.Parse(r.FKQCategory));
                            cmd.Parameters.AddWithValue("@Cls", int.Parse(r.Cls));
                            cmd.Parameters.AddWithValue("@Quersion", r.Quersion);
                            cmd.Parameters.AddWithValue("@OptionA", r.OptionA);
                            cmd.Parameters.AddWithValue("@OptionB", r.OptionB);
                            cmd.Parameters.AddWithValue("@OptionC", r.OptionC);
                            cmd.Parameters.AddWithValue("@OptionD", r.OptionD);
                            cmd.Parameters.AddWithValue("@Answer", r.Answer);
                            cmd.Parameters.AddWithValue("@IsActive", int.Parse(r.IsActive));

                            cmd.ExecuteNonQuery();
                        }

                        Console.WriteLine("CSV imported successfully!");
                    }
                }
            }
        }
    }
}

