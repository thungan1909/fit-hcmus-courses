/******************************************************************************

Welcome to GDB Online.
GDB online is an online compiler and debugger tool for C, C++, Python, Java, PHP, Ruby, Perl,
C#, VB, Swift, Pascal, Fortran, Haskell, Objective-C, Assembly, HTML, CSS, JS, SQLite, Prolog.
Code, Compile, Run and Debug online from anywhere in world.

*******************************************************************************/
using System;
using System.Collections.Generic;
namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {

            var students = new List<student>();
            for (int i = 0; i < 10; i++)
            {
                students.Add(new student());
            }
            Console.WriteLine("Generate random 10 students");
            for (int i = 0; i < students.Count; i++)
            {

                Console.WriteLine("Student [{0}]:", i + 1);
                Console.WriteLine("+ StudentID: {0}", students[i].ID);
                Console.WriteLine("+ FullName: {0}", students[i].FullName);
                Console.WriteLine("+ GPA: {0}", students[i].GPA);
                Console.WriteLine("+ Address: {0}", students[i].Address);
                Console.WriteLine("                                                                  ");
            }
            Console.WriteLine("*****************************************************************");
            Console.WriteLine("Print out the average GPA of all the students");
            double AVG = 0;
            double SUM = 0;
            for (int i = 0; i < students.Count; i++)
            {
                SUM = students[i].GPA + SUM;
            }
            AVG = SUM / students.Count;
            AVG = Math.Round(AVG, 2);
            Console.WriteLine("AVG= {0}", AVG);
            Console.WriteLine("*****************************************************************");
            Console.WriteLine("Print out full information of the top 3 students with highest GPA");
            var HighGPAStudents = new List<student>();
            int[] flag = { -1, -1, -1 };
         
            int index = 0; //luu index cua student
            for (int i = 0; i < 3; i++)
            {
                double max = 0;

                for (int j = 0; j < students.Count; j++)
                {
                    if (j != flag[0] && j!= flag[1] && j!=flag[2])
                    {
                        if (students[j].GPA-max > 0.0000000000001)
                        {
                            max = students[j].GPA;
                            index = j;
                        }
                    }
                }
                HighGPAStudents.Add(students[index]);
                flag[i] = index;
               
            }
            for (int i = 0; i < HighGPAStudents.Count; i++)
            {

                Console.WriteLine("Student [{0}]:", i + 1);
                Console.WriteLine("+ StudentID: {0}", HighGPAStudents[i].ID);
                Console.WriteLine("+ FullName: {0}", HighGPAStudents[i].FullName);
                Console.WriteLine("+ GPA: {0}", HighGPAStudents[i].GPA);
                Console.WriteLine("+ Address: {0}", HighGPAStudents[i].Address);
                Console.WriteLine("                                                                  ");
            }
        }
    }
        class student
        {
            public string ID = RandomID();
            public string FullName = RandomName();
            public double GPA = RandomGPA();
            public string Address = RandomAddress();

            static public string RandomID()
            {
                string ID;
                Random r = new Random();
                int yearID = r.Next(18, 20);
                ID = yearID.ToString();
                int nextNumID;
                for (int i = 0; i < 6; i++)
                {
                    nextNumID = r.Next(0, 9);
                    ID = ID + nextNumID.ToString();
                }
                return ID;
            }
            static public string RandomName()
            {
                string FullName;
                Random r = new Random();
                string[] FirstNames ={"Nguyen","Tran","Le","Pham","Hoang","Huynh","Phan","Vu","Vo","Dang","Bui","Do","Ho","Ngo","Duong",
"Ly"};
                string[] MiddleNames = { "Tuan", "Duc", "Minh", "Thanh", "Cong", "Tan", "Vinh", "Quoc", "Anh", "An", "Anh", "Bac", "Bach", "Chien", "Cuong", "Dang", "Dao", "Dat", "Do", "Doan", "Duc", "Dung", "Duy", "Giang", "Hai", "Bao" };
                string[] LastNames = { "Hong", "Bich", "Doan", "Phuong", "Nha", "Thanh", "Thao", "Thien", "Ha", "Tu", "Vy", "Tuong", "Han", "An", "Thuy", "Ha", "Chau", "Ngan", "Nhung", "Anh", "Trinh", "Phuong", "Mai", "Thanh", "Quyen" };
                string FirstName = FirstNames[r.Next(0, FirstNames.Length)];
                string MiddleName = MiddleNames[r.Next(0, MiddleNames.Length)];
                string LastName = LastNames[r.Next(0, LastNames.Length)];
                FullName = FirstName + " " + MiddleName + " " + LastName;
                return FullName;
            }
            static public double RandomGPA()
            {
                double GPA;
                Random r = new Random();
                GPA = (r.NextDouble()*9+1);
                GPA= Math.Round(GPA, 2);
                return GPA;
            }
            static public string RandomAddress()
            {
                string Address;
                Random r = new Random();
                int Number = r.Next(1, 100);

                string[] StreetNames ={"Street Pasteur","Street Le Thi Rieng","Street Bui Thi Xuan","Street Ly Tu Trong","Street Bui Vien",
      "Street Co Giang","Street Tran Hung Dao","Street Cong Quynh","Street Nguyen Cong Tru","Street Luong Dinh Cua",
      "Street Mai Chi Tho","Street Pham Cong Tru","Street Nguyen Duy Trinh","Street Nguyen Thi Dinh","Street Ba Huyen Thanh Quan",
      "Street Cach Mang Thang Tam", "Street Tran Quang Dieu","Street Tran Quoc Thao","Street Dien Bien Phu","Street Nguyen Thi Minh Khai"};
                int Ward = r.Next(1, 10);
                int District = r.Next(1, 10);

                string StreetName = StreetNames[r.Next(0, StreetNames.Length)];

                Address = Number.ToString() + ", " + StreetName + ", " + Ward.ToString() + " Ward, " + District.ToString() + " District";
                return Address;
            }
        }
    }
