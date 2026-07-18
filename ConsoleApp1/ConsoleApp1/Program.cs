using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string csvFilePath = @"D:\Temp\test.csv";
            string connectionString = "Data Source=LAPTOP-JG6Q75OL;Initial Catalog=testapp;Integrated Security=True;";

            try
            {
                if (!File.Exists(csvFilePath))
                {
                    Console.WriteLine("CSV file not found!");
                    return;
                }

                string[] lines = File.ReadAllLines(csvFilePath);

                // Skip header row (line 0)
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] values = lines[i].Split(',');

                    // Handle commas safely if using quoted fields
                    if (values.Length < 8)
                    {
                        Console.WriteLine($"Skipping invalid row {i + 1}");
                        continue;
                    }

                    int fkCategory = int.Parse(values[0]);
                    string question = values[1];
                    string optionA = values[2];
                    string optionB = values[3];
                    string optionC = values[4];
                    string optionD = values[5];
                    string answer = values[6];
                    bool isActive = values[7] == "1";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = @"INSERT INTO Tbl_Question 
                                         (FKQCategory, Quersion, OptionA, OptionB, OptionC, OptionD, Answer, IsActive)
                                         VALUES (@FKQCategory, @Question, @OptionA, @OptionB, @OptionC, @OptionD, @Answer, @IsActive)";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@FKQCategory", fkCategory);
                            cmd.Parameters.AddWithValue("@Question", question);
                            cmd.Parameters.AddWithValue("@OptionA", optionA);
                            cmd.Parameters.AddWithValue("@OptionB", optionB);
                            cmd.Parameters.AddWithValue("@OptionC", optionC);
                            cmd.Parameters.AddWithValue("@OptionD", optionD);
                            cmd.Parameters.AddWithValue("@Answer", answer);
                            cmd.Parameters.AddWithValue("@IsActive", isActive);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    Console.WriteLine($"Inserted row {i}");
                }

                Console.WriteLine("✅ All rows inserted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
        }
    }
}
