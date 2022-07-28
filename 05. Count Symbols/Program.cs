using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            SortedDictionary<char, int> chars = new SortedDictionary<char, int>();
            for (int i = 0; i < text.Length; i++)
            {
                if (!chars.ContainsKey(text[i]))
                {
                    chars[text[i]] = 1;
                }
                else
                {
                    chars[text[i]]++;
                }
            }
            foreach (var chr in chars)
            {
                Console.WriteLine($"{chr.Key}: {chr.Value} time/s");
            }
        }
    }
}
