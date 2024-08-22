using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Match_Simulator
{
    internal class Team
    {
        public string Name { get; set; }
        public List<Player> PlayerList { get; set; }
       
        public Coach coach;

        public void AddPlayer(Player player)
        {
            PlayerList.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            PlayerList.Remove(player);
        }
    }
}
