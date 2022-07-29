using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> submitions = new Dictionary<string, int>();
            Dictionary<string, Student> students = new Dictionary<string, Student>();
            string input;
            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] cmd = input.Split("-");
                if (cmd.Length == 3)
                {
                    Student student = new Student(cmd[0]);
                    if (!students.ContainsKey(cmd[0]))
                    {
                        students.Add(cmd[0], student);
                    }
                    if (students[cmd[0]].Points < int.Parse(cmd[2]))
                    {
                        students[cmd[0]].Points = int.Parse(cmd[2]);
                    }
                    if (!submitions.ContainsKey(cmd[1]))
                    {
                        submitions.Add(cmd[1], 0);
                    }
                    submitions[cmd[1]]++;
                }
                if (cmd.Length == 2)
                {
                    if (students.ContainsKey(cmd[0]))
                    {
                        students.Remove(cmd[0]);
                    }
                }
            }
            Console.WriteLine("Results:");
            foreach (var student in students.OrderByDescending(x => x.Value.Points).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{student.Key} | {student.Value.Points}");
            }
            Console.WriteLine("Submissions:");
            foreach (var submition in submitions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{submition.Key} - {submition.Value}");
            }

        }
    }
    class Student
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public Dictionary<string, int> Contests { get; set; }
        public Student(string name)
        {
            this.Name = name;
            this.Contests = new Dictionary<string, int>();
        }
    }

}
