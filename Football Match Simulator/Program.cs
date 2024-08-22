namespace Football_Match_Simulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1. Create teams and add players to them
            Team team1 = new Team() {Name = "Team1", PlayerList = new List<Player>()};
            Team team2 = new Team() { Name = "Team2", PlayerList = new List<Player>() };

            Coach coach1 = new Coach();
            coach1.Name = "hussien";
            team1.coach = coach1;

            var team1players = new List<Player>()
            {
                new Player() { Name = "Ahmed", Age = 19, Team = "Team1", HasBall = false, T_Shirt_Number = 1, PR_Lleg = R_Lleg.LEFT },
                new Player() { Name = "Ali", Age = 23, Team = "Team1", HasBall = false, T_Shirt_Number = 2, PR_Lleg = R_Lleg.LEFT },
                new Player() { Name = "Mohamed", Age = 24, Team = "Team1", HasBall = false, T_Shirt_Number = 3, PR_Lleg = R_Lleg.LEFT },
            };

            Coach coach2 = new Coach();
            coach2.Name = "saeed";
            team2.coach = coach2;

            var team2players = new List<Player>()
            {
                new Player() { Name = "hassan", Age = 30, Team = "Team2", HasBall = false, T_Shirt_Number = 1, PR_Lleg = R_Lleg.LEFT },
                new Player() { Name = "Ahmed", Age = 35, Team = "Team2", HasBall = false, T_Shirt_Number = 2, PR_Lleg = R_Lleg.LEFT },
                new Player() { Name = "Mohamed", Age = 29, Team = "Team2", HasBall = false, T_Shirt_Number = 3, PR_Lleg = R_Lleg.LEFT },
            };

            for (int i = 0; i < team1players.Count; i++)
            {
                team1.AddPlayer(team1players[i]);
            }

            for (int i = 0; i < team2players.Count; i++)
            {
                team1.AddPlayer(team2players[i]);
            }


            Console.WriteLine($"{team1.Name} Coach: {team1.coach.Name}");
            Console.WriteLine($"{team1.Name} players: ");
            foreach(var player in team1players)
            {
                Console.WriteLine(player.Name);
            }
            Console.WriteLine("");

            Console.WriteLine($"{team2.Name} Coach: {team2.coach.Name}");
            Console.WriteLine($"{team2.Name} players: ");
            foreach (var player in team2players)
            {
                Console.WriteLine(player.Name);
            }
            Console.WriteLine("--------------------------------");

            #endregion

            #region 2. Assign a coach to a team
            coach1.Team = "Team1";

            coach1.Team = "Team2";
            #endregion

            #region 4. Simulate player training by a coach
            coach1.TrainPlayer(team1players[0]);
            coach1.TrainPlayer(team1players[2]);

            coach2.TrainPlayer(team2players[0]);
            coach2.TrainPlayer(team2players[1]);
            Console.WriteLine("--------------------------------");
            #endregion

            #region 3. Start a match between two teams in the stadium
            Match match1 = new Match();
            match1.HomeTeam = team1;
            match1.AwayTeam = team2;
            match1.StartMatch();
            Console.WriteLine("--------------------------------");
            #endregion

           /* #region Match ended
            match1.EndMatch();
            Console.WriteLine("--------------------------------");
            #endregion
           */

            #region 5. Allow players to pass the ball to other players
            Ball ball1 = new Ball();
            ball1.Possessor = team1players[2];
            Console.WriteLine($"the ball now with {ball1.Possessor.Name}");
            Console.WriteLine("--------------------------------");
            #endregion

        }
    }
}