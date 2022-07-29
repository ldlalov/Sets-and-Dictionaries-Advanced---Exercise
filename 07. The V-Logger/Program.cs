using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class Vloger
    {
        public string Name { get; set; }
        public HashSet<string> Followers { get; set; }
        public HashSet<string> Following { get; set; }
        public Vloger(string name, HashSet<string> followers, HashSet<string> following)
        {
            this .Name = name;
            this .Followers = followers;
            this .Following = following;
        }
            
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //HashSet<Vloger> vlogers = new HashSet<Vloger>();
            Dictionary<string, Vloger> vlogers = new Dictionary<string, Vloger>();
            Dictionary<string, HashSet<string>> following = new Dictionary<string, HashSet<string>>();//stores people witch the user follow;

            string command;
            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] cmd = command.Split(" ");
                switch (cmd[1])
                {
                    case "joined":
                        Vloger vloger = new Vloger(cmd[0],new HashSet<string>(),new HashSet<string>());
                        if (!vlogers.ContainsKey(vloger.Name))
                        {
                            vlogers.Add(vloger.Name,vloger);
                        }
                        break;
                    case "followed":
                        if (vlogers.ContainsKey(cmd[0]) && vlogers.ContainsKey(cmd[2]) && cmd[0] != cmd[2])
                        {
                                vlogers[cmd[2]].Followers.Add(cmd[0]);
                                vlogers[cmd[0]].Following.Add(cmd[2]);
                        }
                        break;
                }
            }
            Console.WriteLine($"The V-Logger has a total of {vlogers.Count} vloggers in its logs.");
            int row = 1;
            foreach (var vloger in vlogers.OrderByDescending(x => x.Value.Followers.Count).ThenBy(x => x.Value.Following.Count))
            {
                Console.WriteLine($"{row}. {vloger.Key} : {vloger.Value.Followers.Count} followers, {vloger.Value.Following.Count} following");
                if (row == 1)
                {
                    foreach (var follower in vloger.Value.Followers.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                row++;
            }
        }
    }
}
