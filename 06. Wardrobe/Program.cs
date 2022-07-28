using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < count; i++)
            {
                string[] garment = Console.ReadLine().Split(" -> ");
                string[] type = garment[1].Split(",");
                if (!clothes.ContainsKey(garment[0]))
                {
                    clothes.Add(garment[0], new Dictionary<string, int>());
                }
                foreach (var item in type)
                {
                    if (!clothes[garment[0]].ContainsKey(item))
                    {
                        clothes[garment[0]].Add(item, 1);
                    }
                    else
                    {
                        clothes[garment[0]][item]++;
                    }
                }
            }
            string[] dress = Console.ReadLine().Split();
            foreach (var garment in clothes)
            {
                Console.WriteLine($"{garment.Key} clothes:");
                foreach (var type in garment.Value)
                {
                    Console.Write($"* {type.Key} - {type.Value}");
                    if (dress[0] == garment.Key && dress[1] == type.Key)
                    {
                        Console.WriteLine($" (found!)");
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
