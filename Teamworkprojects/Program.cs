using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teamworkprojects
{
    class Team
    {
        public string Name { get; set; }
        public List<string> Users { get; set; }
        public string Creator { get; set; }
    }
    internal class Program
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine().Split('-');
                string userName = tokens[0];
                string teamName = tokens[1];


                if (teams.Any(t => t.Creator.Equals(userName)))
                {
                    Console.WriteLine($"{userName} cannot create another team!");
                }
                else if (teams.Any(t => t.Name.Equals(teamName)))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else
                {
                    Team team = new Team()
                    {
                        Name = teamName,
                        Creator = userName,
                    };
                    teams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {userName}!");
                }
            }

            string input = Console.ReadLine();
            while (!input.Equals("end of assignment"))
            {
                string delimer = "->";
                string[] tokens = Console.ReadLine().Split(new string[] { delimer }, StringSplitOptions.RemoveEmptyEntries);
                string userName = tokens[0];
                string teamName = tokens[1];

                if (!teams.Any(t => t.Name.Equals(teamName)))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }

                foreach (var team in teams)
                {
                    if (team.Users == null
                     || team.Users.Any(u => u.Equals(userName))
                     || team.Creator.Equals(userName))
                    {
                        Console.WriteLine($"Member {userName} cannot join team {teamName}!");
                    }
                }

                foreach (var team in teams.Where(t => t.Name.Equals(teamName)))
                {
                    if (team.Users == null)
                    {
                        List<string> users = new List<string>() { userName };
                        team.Users = users;
                    }
                    else team.Users.Add(userName);
                }

                input = Console.ReadLine();
            }
        }
    }
}
