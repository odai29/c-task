using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    internal class Login
    {bool IsLog=false;
        
        
        public void Selection()

        {

            if (IsLog)
            {
                while (true)
                {
                    Console.WriteLine("******Main Menu******");
                    Console.WriteLine(" ");
                    Console.WriteLine("[1] Student Menu");
                    Console.WriteLine("[2] Course Menu");
                    Console.WriteLine("[3] Score Menu");
                    Console.WriteLine("[0] Exite");
                    Console.WriteLine("Enter Your Choice");
                    string NumberOfChoice = Console.ReadLine();
                    switch (NumberOfChoice)
                    {
                        case "1":
                            Console.Clear();
                            Student student = new Student();
                            student.SelectStudents();
                            break;
                        case "2":
                            Console.Clear();
                            course course = new course();
                            course.SelectCourse();
                            break;
                        case "3":
                            Console.Clear();
                            Score score = new Score();
                            score.SelectScore();
                            break;
                        case "0":
                            Console.Clear();
                            Exiet exiet = new Exiet();
                            exiet.exiet();
                            break;
                        default:
                            Console.WriteLine("The Number Out Of Range");
                            break;

                    }

                }
            }
        }
        public Login() {
            
            int MaxAttempLogin = 1;
            while (MaxAttempLogin <= 3)
            {
                Console.WriteLine("******LogIn******");

                Console.WriteLine("user name : ");
                string user = Console.ReadLine();
                Console.WriteLine("your password :");
                int pass = Convert.ToInt32(Console.ReadLine());
                if (pass == 1234 && user == "odai")
                {
                    Console.Clear();
                    IsLog = true;
                    break;
                }


                else
                {
                    MaxAttempLogin++;
                    Console.WriteLine("Login failed.");
                    Console.Clear() ;   
                }
            }
            
        }
    }
        
    
}
