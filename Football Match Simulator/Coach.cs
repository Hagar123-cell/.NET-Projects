using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Match_Simulator
{
    internal sealed class Coach: Person
    {
        public string Team { get; set; }
    
        public void TrainPlayer(Player player)
        {
            Console.WriteLine($"Coach {this.Name} trains {player.Name}");
        }
    }
}
