using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Match_Simulator
{
    public enum R_Lleg { LEFT = 0, RIGHT = 1 };

    internal class Player: Person, IComparable<Player>, ITraining
    {
        //string Name;
       // public string Name { get; set; }
        public int T_Shirt_Number { get; set; }
        public string Team { get; set; }
        public int Age { get; set; }
        public R_Lleg PR_Lleg { get; set; }
        public bool HasBall { get; set; }

        public void PassBall(Player receiver)
        {
            receiver.HasBall = true;
            this.HasBall = false;
        }

        public void ShootBall()
        {

        }

        public int CompareTo(Player? other)
        {
            return this.Age.CompareTo(other.Age);
        }

        public void DoTraining()
        {
            Console.WriteLine($"{this.Name} is being trained now");
        }
    }
}
