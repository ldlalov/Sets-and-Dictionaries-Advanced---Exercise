using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> vlogers = new Dictionary<string, HashSet<string>>();
            Dictionary<string, HashSet<string>> following = new Dictionary<string, HashSet<string>>();//stores people witch the user follow;

            string command;
            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] cmd = command.Split(" ");
                switch (cmd[1])
                {
                    case "joined":
                        if (!vlogers.ContainsKey(cmd[0]))
                        {
                            vlogers.Add(cmd[0], new HashSet<string>());
                            following.Add(cmd[0], new HashSet<string>());
                        }
                        break;
                    case "followed":
                        if (vlogers.ContainsKey(cmd[0]) && vlogers.ContainsKey(cmd[2]) && cmd[0] != cmd[2])
                        {
                                vlogers[cmd[2]].Add(cmd[0]);
                                following[cmd[0]].Add(cmd[2]);
                        }
                        break;
                }
            }
            Console.WriteLine($"The V-Logger has a total of {vlogers.Count} vloggers in its logs.");
            int row = 1;
            foreach (var vloger in vlogers.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{row}. {vloger.Key} : {vloger.Value.Count} followers, {following[vloger.Key].Count} following");
                if (row == 1)
                {
                    foreach (var follower in vloger.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                row++;
            }
        }
    }
}
