using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    internal class Score
    {
        public void SelectScore()
        {
            Console.WriteLine("******Score menu******");
            Console.WriteLine("");
            Console.WriteLine("[1] Add Score");
            Console.WriteLine("[2] Edit Score");
            Console.WriteLine("[3] Remove Score");
            Console.WriteLine("[4] print Score in file");
            Console.WriteLine("[5] Average Score ");
            Console.WriteLine("[0] Exite");
            string Choice = Console.ReadLine();
            switch (Choice)
            {
                case "1":
                    Console.Clear();
                    AddScore();

                    break;
                case "2":
                    Console.Clear();
                    UpdateScore();
                    break;
                case "3":
                    Console.Clear();
                    DeleteScore();
                    break;
                case "4":
                    Console.Clear();
                    PrintScoreInFile();
                    break;
                case "5":
                        Console.Clear();
                    AverageScore();
                    break;
                case "0":
                        Console.Clear();
                    Exiet exiet = new Exiet();
                    exiet.exiet();
                    break;

                default:
                    Console.WriteLine("wrong choice");
                    break;
            }

        }
        public void AddScore()
        {
            Console.WriteLine("enter  Score");
            int Score =Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("enter  Courseid");
            int Courseid = Convert.ToInt32(Console.ReadLine());

            Connsql.execute("insert into Score(Score,Courseid) values ('" + Score + "','" + Courseid + "')");
            Console.WriteLine("data saved");
             

        }
        public void UpdateScore()
        {
            Console.WriteLine("enter Courseid");
            int Courseid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter  Score");
            string Score = Console.ReadLine();

            Connsql.execute("update Score set Score = '" + Score + "' where id ='" + Courseid + "'");
            Console.WriteLine("data saved");
        }
        public void DeleteScore()
        {

            Console.WriteLine("enter id");
            int id = Convert.ToInt32(Console.ReadLine());
            Connsql.execute("Delete from Score where id ='" + id + "'");
            Console.WriteLine("data saved");
            Console.Clear();
        }
        public void PrintScoreInFile()
        {
            try
            {
                string filePath = "C:\\odai\\allScore.txt";

                SqlDataReader reader = Connsql.readsql("SELECT id, Score, Courseid FROM Score ");

                using (StreamWriter writer = new StreamWriter(filePath))
                {

                    writer.WriteLine("id, Score, Courseid");


                    while (reader.Read())
                    {
                        int Id = Convert.ToInt32(reader["id"]);
                        string score = reader["Score"].ToString();
                        string Courseid = reader["Courseid"].ToString();

                        writer.WriteLine($"{Id}\t{score}\t{Courseid}");
                    }
                }

                Console.WriteLine("All data has been written to the file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }




        }
        public void AverageScore()
        {



            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-2O0E8N7\SQLEXPRESS;Initial Catalog=school1;Integrated Security=True"))
                {
                    
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT Courseid, AVG(Score) AS AverageScore FROM Score GROUP BY Courseid", connection))
                    {
                       
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            
                            while (reader.Read())
                            {
                                string courseid = reader["Courseid"].ToString();
                                double averageScore = Convert.ToDouble(reader["AverageScore"]);

                                Console.WriteLine($"Average score for {courseid}: {averageScore:F2}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
    
}
