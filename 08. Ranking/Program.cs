using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,Student> students = new Dictionary<string, Student>();
            Dictionary<string, string> contests = new Dictionary<string, string>();
            string input;
            while((input = Console.ReadLine()) != "end of contests")
            {
                string[] cmd = input.Split(":");
                if (!contests.ContainsKey(cmd[0]))
                {
                    contests.Add(cmd[0],cmd[1]);
                }
            }
            while((input = Console.ReadLine()) != "end of submissions")
            {
                string[] cmd = input.Split("=>");
                Student student = new Student(cmd[2]);
                if (contests.ContainsKey(cmd[0]) && contests[cmd[0]] == cmd[1])
                {
                    if (!students.ContainsKey(cmd[2]))
                    {
                        students.Add(cmd[2], student);
                    }
                    if (!students[cmd[2]].Contests.ContainsKey(cmd[0]))
                    {
                        students[cmd[2]].Contests.Add(cmd[0], 0);
                    }
                    if (students[cmd[2]].Contests[cmd[0]] < int.Parse(cmd[3]))
                    {
                        students[cmd[2]].Contests[cmd[0]] = int.Parse(cmd[3]);
                    }
                }
            }
            foreach (var student in students)
            {
                student.Value.Points = student.Value.Contests.Values.Sum();
            }
            Console.WriteLine($"Best candidate is {students.OrderByDescending(x => x.Value.Points).First().Key} with total {students.OrderByDescending(x => x.Value.Points).First().Value.Points} points.");
            Console.WriteLine("Ranking:");
            foreach (var student in students.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{student.Key}");
                foreach (var contest in student.Value.Contests.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
    class Student
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public Dictionary<string,int> Contests { get; set; }
        public Student(string name)
        {
            this.Name = name;
            this.Contests = new Dictionary<string,int>();
        }
    }
}
