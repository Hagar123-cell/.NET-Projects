using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Match_Simulator
{
    internal class Ball
    {
        public Player Possessor { get; set; }
        public bool IsInPlay { get; set; }
    }
}
