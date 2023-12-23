using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    internal class Student
    {
        public void SelectStudents()
        {
            Console.WriteLine("******Student menu******");
            Console.WriteLine("");
            Console.WriteLine("[1] Add Student");
            Console.WriteLine("[2] Edit Student");
            Console.WriteLine("[3] Remove A Student");
            Console.WriteLine("[4] Display Statics Students");
            Console.WriteLine("[5] Search Student by id ");
            Console.WriteLine("[0] Exite");
            string Choice = Console.ReadLine();
            switch (Choice)
            {
                case "1":

                    AddStudent();
                    

                    break;
                case "2":
                    
                    UpdateStudent();
                    break;
                case "3":
                    
                    DeleteStudent();
                    break;
                case "4":
                   
                    DisplayStaticsStudents();
                    break;
                case "5":
                    Console.Clear();
                    SearchStudent();
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


        public void AddStudent()
        {
            Console.WriteLine("enter Full Name");
            string Fullname = Console.ReadLine();
            Console.WriteLine("enter your gender");
            string Gender = Console.ReadLine();

            Connsql.execute("insert into student(FullName, Gender) values ('" + Fullname + "','" + Gender + "')");
            Console.WriteLine("data saved");
           
        }
        public void UpdateStudent()
        {

            Console.WriteLine("enter id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter full name");
            string FullName = Console.ReadLine();

            Connsql.execute("update student set FullName = '" + FullName + "' where id ='" + id + "'");
            Console.WriteLine("data saved");
        }
        public void DeleteStudent()
        {

            Console.WriteLine("enter id");
            int id = Convert.ToInt32(Console.ReadLine());
            Connsql.execute("Delete from student where id ='" + id + "'");
            Console.WriteLine("data saved");
           
        }
        public void DisplayStaticsStudents()
        {
            SqlDataReader reader = Connsql.readsql("select count (*) as [totalstudent] from Student; ");
            reader.Read();
            int totalStudents = Convert.ToInt32(reader["totalstudent"]);

            Console.WriteLine($"Total Students: {totalStudents}");


            


        }
        public void SearchStudent()
        {
            Console.WriteLine("enter id");
            int id= Convert.ToInt32(Console.ReadLine());
            SqlDataReader reader = Connsql.readsql("SELECT FullName, Gender FROM Student WHERE ID = " + id);

            if (reader.Read())
            {
                string fullName= reader["FullName"].ToString();
                string gender = reader["Gender"].ToString();
                Console.WriteLine($"Full Name: {fullName}, Gender: {gender}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
            reader.Close();
            
        }
    
    }
}

