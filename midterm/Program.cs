using System;


namespace midterm
{
    class Program
    {
        string[] TeamName = { "Real Madrid", "Barcelona", "Bayern Munich", "Juventus", "Paris Saint-Germain" };
        int[,] TeamPoints = new int[,]
        {
             { 2, 1, 0, 3, 2 },   // Points of Team A 
             { 1, 3, 1, 0, 2 },   // Points of Team B 
             { 0, 1, 1, 1, 3 },   // Points of Team C 
             { 2, 0, 3, 1, 1 },   // Points of Team D 
             { 3, 2, 1, 0, 0 }    // Points of Team E
        };

        int Leaguesize = 5;
        int MatchNo = 5;


        int CalculateTotalPoints(string teamname)
        {
            int index = Array.IndexOf(TeamName, teamname);
            int total = 0;
            for (int i = 0; i < MatchNo; i++)
            {
                total += TeamPoints[index, i];
            }
            return total;
        }
        int[] CountMatchResults(string teamname)
        {
            int index = Array.IndexOf(TeamName, teamname);
            int[] total = { 0, 0, 0, 0 };
            for (int i = 0; i < MatchNo; i++)
            {
                switch (TeamPoints[index, i])
                {
                    case 0:
                        total[0]++;
                        break;
                    case 1:
                        total[1]++;
                        break;
                    case 2:
                        total[2]++;
                        break;
                    case 3:
                        total[3]++;
                        break;
                }
            }
            return total;
        }

        void OutputTeamInfo(string teamname)
        {
            Console.WriteLine("Team Name: {0}", teamname);
            Console.WriteLine("Total Points: {0}", CalculateTotalPoints(teamname));
            int[] wins = CountMatchResults(teamname);
            Console.WriteLine("Away wins: {0}", wins[3]);
            Console.WriteLine("Home wins: {0}", wins[2]);
            Console.WriteLine("Drawn matches: {0}", wins[1]);
            Console.WriteLine("Lost matches: {0}", wins[0]);
        }

        void FindTeamWithHighestPoint()
        {
            int highest = CalculateTotalPoints(TeamName[0]);
            string team = TeamName[0];
            for (int i = 1; i < Leaguesize; i++)
            {
                int points = CalculateTotalPoints(TeamName[i]);
                if (points > highest)
                {
                    highest = points;
                    team = TeamName[i];
                }
            }
            Console.WriteLine("Team: {0} has highest points:{1}", team, highest);
        }

        void FindTeamWithLowestPoints()
        {
            int lowest = CalculateTotalPoints(TeamName[0]);
            string team = TeamName[0];
            for (int i = 1; i < Leaguesize; i++)
            {
                int points = CalculateTotalPoints(TeamName[i]);
                if (points < lowest)
                {
                    lowest = points;
                    team = TeamName[i];
                }
            }
            Console.WriteLine("Team: {0} has lowest points:{1}", team, lowest);
        }

        string GetTeamStats(string team)
        {
            int[] wins = CountMatchResults(team);
            return "Team Name:" + team + "\nTotal Points:" + CalculateTotalPoints(team) + "\nAway wins:" + wins[3] + "\nHome wins:" + wins[2] + "\nDrawn matches:" + wins[1] + "\nLost matches:" + wins[0];
        }
        static void Main(string[] args)
        {
            Program A = new Program();
            A.OutputTeamInfo("Juventus");
            A.FindTeamWithHighestPoint();
            A.FindTeamWithLowestPoints();
            Console.WriteLine("Enter Team Name:");
            string team = Console.ReadLine();
            Console.WriteLine(A.GetTeamStats(team));
            Console.ReadKey();

        }
    }
}