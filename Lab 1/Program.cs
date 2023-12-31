﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace Lab_1
{
    //public class OverflowException: Exception
    //{
    //    public OverflowException() : base("Error") { }
    //}

    public class Program
    {
        public static void PrintAverageGPA()
        {
            //* Task 1 *//

            string path = @"D:\Study\Semester 3, Winter 2023\CSE 4308 Lab  Database Managemment System I\Lab 1\grades.txt";


            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);

                int count = 0;
                double total_cgpa = 0;

                foreach (string line in lines)
                {
                    //Console.WriteLine(line);

                    string[] strings = line.Split(";", 3, StringSplitOptions.None);

                    double cgpa = Convert.ToDouble(strings[1]);
                    total_cgpa += cgpa;
                    count++;
                }


                double average = total_cgpa / count;
                average = Math.Round(average, 2);

                Console.Write("Average CGPA: ");
                Console.WriteLine(average + "\n");
            }
        }

        public static void AddStudent()
        {
            //* Task 2 *//
            string path = @"D:\Study\Semester 3, Winter 2023\CSE 4308 Lab  Database Managemment System I\Lab 1\grades.txt";
            int id=0;

            Console.WriteLine("Add GPA Input");
            Console.Write("Student Id: ");

            try 
            {
                int idd = Convert.ToInt32(Console.ReadLine());

                if (idd < 2e9 || idd > 0) 
                {
                    id = idd;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error- "+ex.Message);
                return;
            }
            
            Console.Write("GPA: ");
            double gpa = Convert.ToDouble(Console.ReadLine());
            Console.Write("Semester: ");
            int semester = Convert.ToInt32(Console.ReadLine());


            if (id>2e9 || id<=0|| gpa < 2.50 || gpa > 4.00 || semester <= 0 || semester >= 8)
            {
                Console.WriteLine("Error");
            }

            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(id + ";" + gpa + ";" + semester);
                }
                Console.WriteLine("Input added");
            }
        }

        public static void LowestSemester()
        {
            //* Task 3*//

            Console.Write("Student Id: ");
            int id3 = Convert.ToInt32(Console.ReadLine());

            string path = @"D:\Study\Semester 3, Winter 2023\CSE 4308 Lab  Database Managemment System I\Lab 1\grades.txt";
            string path2 = @"D:\Study\Semester 3, Winter 2023\CSE 4308 Lab  Database Managemment System I\Lab 1\studentInfo.txt";
            bool account = false;

            if (File.Exists(path2))
            {
                string[] lines = File.ReadAllLines(path2);

                foreach (string line in lines)
                {
                    //Console.WriteLine(line);

                    string[] strings = line.Split(";", 5, StringSplitOptions.None);

                    if (id3 == Convert.ToInt32(strings[0]))
                    {
                        Console.WriteLine(strings[1]);
                        account = true;
                        break;
                    }
                }

                if (account == false)
                {
                    Console.WriteLine("Error");
                }
            }

            if (File.Exists(path) && account == true)
            {
                string[] lines = File.ReadAllLines(path);
                account = false;

                double lowest_cgpa = 4.00;
                int lowest_semester = 0;

                foreach (string line in lines)
                {
                    string[] strings = line.Split(";", 3, StringSplitOptions.None);

                    if (id3 == Convert.ToInt32(strings[0]))
                    {
                        account = true;
                        double cgpa = Convert.ToDouble(strings[1]);
                        if (cgpa < lowest_cgpa)
                        {
                            lowest_cgpa = cgpa;
                            lowest_semester = Convert.ToInt32(strings[2]);
                        }
                    }
                }

                if (account == false)
                {
                    Console.WriteLine("Error");
                }
                else
                {
                    Console.WriteLine(lowest_semester);
                }
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Press 1 to Print Average CGPA");
            Console.WriteLine("Press 2 to Add a new student");
            Console.WriteLine("Press 3 to Print the semester in which a student got the lowest CGPA\n");

            int key= Convert.ToInt32(Console.ReadLine());

            switch (key)
            {
                case 1: PrintAverageGPA(); break;
                case 2: AddStudent(); break;
                case 3: LowestSemester(); break;
                default: Environment.Exit(0); break;
            }
        }
    }
}