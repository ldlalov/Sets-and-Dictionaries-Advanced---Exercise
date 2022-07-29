using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> userSide = new SortedDictionary<string, List<string>>();
            string input;
            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                if (input.Contains("|"))
                {
                string[] cmd = input.Split(" | ");
                    if (!userSide.ContainsKey(cmd[0]))
                    {
                        userSide.Add(cmd[0], new List<string>());
                        if (!userSide[cmd[0]].Contains(cmd[1]))
                        {
                            userSide[cmd[0]].Add(cmd[1]);
                        }
                    }
                }
                if (input.Contains("->"))
                {
                string[] cmd = input.Split(" -> ");
                        if (!userSide[cmd[1]].Contains(cmd[0]))
                        {
                            userSide[cmd[1]].Add(cmd[0]);
                        Console.WriteLine($"{cmd[0]} joins the {cmd[1]} side!");
                        }
                        else
                        {
                            foreach (var site in userSide)
                            {
                                if (site.Value.Contains(cmd[0]))
                                {
                                    site.Value.Remove(site.Key);
                                }
                            }
                            userSide[cmd[0]].Add(cmd[1]);
                        }
                    
                }
            }
            foreach (var site in userSide)
            {
                Console.WriteLine($"Side: {site.Key}, Members: {site.Value.Count}");
                foreach (var user in site.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}
