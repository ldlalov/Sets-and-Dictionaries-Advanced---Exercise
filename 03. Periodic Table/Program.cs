using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<string> elements = new List<string>();
            SortedSet<string> unique = new SortedSet<string>();
            for (int i = 0; i < count; i++)
            {
                elements.Clear();
                elements = Console.ReadLine().Split(" ").ToList();
                for (int y = 0; y < elements.Capacity; y++)
                {
                    unique.Add(elements[y]);
                }

            }
           foreach (var element in unique)
            {
                Console.Write($"{element} ");
            }
        }
    }
}
