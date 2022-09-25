using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace HashSet_Objecs_Test
{
    class Student : IEqualityComparer<Student>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public bool Equals(Student x, Student y)
        {
            if (x.Name == y.Name && x.Age == y.Age)
            {
                return true;
            }
            return false;
        }

        public int GetHashCode([DisallowNull] Student obj)
        {
            return obj.GetHashCode();
        }

    }
    class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            if (x.Name == y.Name && x.Age == y.Age)
            {
                return true;
            }
            return false;
        }

        public int GetHashCode([DisallowNull] Student obj)
        {
           return obj.Age.GetHashCode() + obj.Name.GetHashCode();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<Student> students = new HashSet<Student>(new StudentComparer());
            students.Add(new Student("Pesho", 1));
            students.Add(new Student("Pesho", 1));
            students.Add(new Student("Pesho", 1));
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name},{student.Age}");
            }
        }
    }
}
