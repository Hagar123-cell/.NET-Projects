using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Match_Simulator
{
    internal class Match
    {
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }

        public void StartMatch()
        {
            Console.WriteLine($"Match started between {HomeTeam.Name} & {AwayTeam.Name}");
        }

        public void EndMatch()
        {
            Console.WriteLine($"Match ended between {HomeTeam.Name} & {AwayTeam.Name}");

        }
    }
}
