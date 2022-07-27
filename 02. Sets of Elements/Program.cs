using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] count = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            HashSet<string> set1 = new HashSet<string>();
            HashSet<string> set2 = new HashSet<string>();
            for (int i = 0; i < count[0]; i++)
            {
                set1.Add(Console.ReadLine());
            }
            for (int i = 0; i < count[1]; i++)
            {
                set2.Add(Console.ReadLine());
            }
            int smaller = 0;
            if (set1.Count>set2.Count)
            {
                foreach (var item in set2)
                {
                    if (set1.Contains(item))
                    {
                        Console.Write($"{item} ");
                    }
                }
            }
            else
            {
                foreach (var item in set1)
                {
                    if (set2.Contains(item))
                    {
                        Console.Write($"{item} ");
                    }
                }
            }
        }
    }
}
