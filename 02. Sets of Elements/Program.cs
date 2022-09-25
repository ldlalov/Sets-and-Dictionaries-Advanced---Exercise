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
            Console.WriteLine(String.Join(" ", set1.Intersect(set2)));
        }
    }
}
