using System;
using System.Collections.Generic;

namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            for (int i = 0; i < count; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (!numbers.ContainsKey(number))
                {
                    numbers[number] = 1;
                }
                else
                {
                numbers[number]++;
                }
            }
            foreach (var number in numbers)
            {
                if (number.Value%2 == 0)
                {
                    Console.WriteLine(number.Key);
                }
            }
        }
    }
}
