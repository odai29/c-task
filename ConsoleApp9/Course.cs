using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    public class course
    {
        public void SelectCourse()
        {
            Console.WriteLine("******Student menu******");
            Console.WriteLine("");
            Console.WriteLine("[1] Add Course");
            Console.WriteLine("[2] Edit Course");
            Console.WriteLine("[3] Remove Course");
            Console.WriteLine("[4] Print Course in file");
            Console.WriteLine("[0] Exite");
            string Choice = Console.ReadLine();
            switch (Choice)
            {
                case "1":
                    Console.Clear();
                    Addcourse();

                    break;
                case "2":
                    Console.Clear();
                    UpdateCourse();
                    break;
                case "3":
                    Console.Clear();
                    DeleteCourse();
                    break;
                case "4":
                    Console.Clear();
                    PrintCourseInFile();



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
        public void Addcourse()
        {
            Console.WriteLine("enter Name Course");
            string NameCourse = Console.ReadLine();
            Console.WriteLine("enter id student");
            int  id=Convert.ToInt32( Console.ReadLine());

            Connsql. execute("insert into Course(NameCourse,Studentid) values ('" +NameCourse + "','" +id+"')");
            Console.WriteLine("data saved");
            

        }
        public void UpdateCourse()
        {
            Console.WriteLine("enter id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter name course");
            string FNameCourse = Console.ReadLine();

            Connsql.execute("update Course set NameCourse = '" + FNameCourse + "' where id ='" + id + "'");
            Console.WriteLine("data saved");
        }
        public void DeleteCourse()
        {

            Console.WriteLine("enter id");
            int id = Convert.ToInt32(Console.ReadLine());
            Connsql.execute("Delete from Course where id ='" + id + "'");
            Console.WriteLine("data saved");
            
        }
       
        public void PrintCourseInFile()
        {
            try { 
            string filePath = "C:\\odai\\allCourse.txt";
            
                SqlDataReader reader = Connsql.readsql("SELECT NameCourse, Studentid FROM Course ");
                    
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    
                    writer.WriteLine("NameCourse, Studentid");

                    
                    while (reader.Read())
                    {
                        string NameCourse = reader["Namecourse"].ToString();
                        string Studentid = reader["studentid"].ToString();

                        writer.WriteLine($"{NameCourse}\t{Studentid}");
                    }
                }

                Console.WriteLine("All data has been written to the file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            
                
                
            
        }
    }
}
