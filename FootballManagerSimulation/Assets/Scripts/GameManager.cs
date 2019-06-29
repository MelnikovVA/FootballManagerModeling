using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

namespace FootballManagerModeling
{

    public class GameManager : MonoBehaviour
    {
        public static GameManager GM;
        public static System.Random Rand = new System.Random();

        public List<FootballTeam> Teams = new List<FootballTeam>();
        public List<Match> Matches = new List<Match>();

        public string ManagerFirstName;
        public string ManagerLastName;

        public int MatchesPlayed;
        public int PlayerTeamIndex;
        public int PlayerBalance = 15000;


        private void Awake()
        {
            GM = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void GetManagerInfo(string managerFirstName, string managerLastName, int chosenTeamIndex)
        {
            this.ManagerFirstName = managerFirstName;
            this.ManagerLastName = managerLastName;
            this.PlayerTeamIndex = chosenTeamIndex;
        }

        public void CreateTeams()
        {
            for (int i=0; i<8; i++)
            {
                Teams.Add(new FootballTeam(i));
            }
        }


        #region Creating and playing a match
        public void CreateMatch(string team1Name, string team2Name)
        {
            FootballTeam Team1 = Teams.Find(x => x.Name == team1Name);
            FootballTeam Team2 = Teams.Find(x => x.Name == team2Name);
            Matches.Add(new Match(Team1, Team2));
        }

        public void PlayMatch(Match match)
        {
            match.TillNextEvent[0] = ModelEvent(match.Teams[0].LambdaAttack, match.Teams[1].LambdaDefense);
            match.TillNextEvent[1] = ModelEvent(match.Teams[1].LambdaAttack, match.Teams[0].LambdaDefense);

            for (int t = 0; t < 5400; t++)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (match.TimeSinceAllEvents[i] + match.TillNextEvent[i] == t)
                    {
                        int randomForward = Rand.Next(0, 4);
                        if ((match.Teams[i].Players[randomForward] as Forward).TryToStrike() == true)
                        {
                            if ((match.Teams[Math.Abs(i - 1)].Players[10] as Goalkeeper).TryToSave() == true)
                            {
                                match.Saves.Add(new Save(t, match.Teams[Math.Abs(i - 1)].Name,
                                    match.Teams[Math.Abs(i - 1)].Players[10] as Goalkeeper));
                            }
                            else
                            {
                                match.Goals.Add(new Goal(t, match.Teams[i].Name,
                                    match.Teams[i].Players[randomForward] as Forward));
                            }
                        }
                        match.TimeSinceAllEvents[i] = t;
                        match.TillNextEvent[i] = ModelEvent(match.Teams[i].LambdaAttack, match.Teams[Math.Abs(i - 1)].LambdaDefense);
                    }
                }
            }

            foreach (var goal in match.Goals)
            {
                Teams.Find(x => x.Name == goal.TeamName).GoalsScored++;
            }
            foreach (var save in match.Saves)
            {
                Teams.Find(x => x.Name == save.TeamName).Saves++;
            }

            int team0Goals = match.Goals.Where(g => g.TeamName == match.Teams[0].Name).Count();
            int team1Goals = match.Goals.Where(g => g.TeamName == match.Teams[1].Name).Count();

            if (team0Goals > team1Goals)
            {
                match.Winner = match.Teams[0].Name;
                match.Loser = match.Teams[1].Name;
                match.WinnerGoals = team0Goals;
                match.LoserGoals = team1Goals;
                Teams.Find(x => x.Name == match.Teams[0].Name).MatchesWon++;
            }
            else
            {
                if (team0Goals == team1Goals)
                {
                    int coinFlip = (int)(Rand.NextDouble() + 0.5);
                    match.Winner = match.Teams[coinFlip].Name;
                    match.Loser = match.Teams[Math.Abs(coinFlip - 1)].Name;
                    if (coinFlip == 1)
                    {
                        match.WinnerGoals = team1Goals;
                        match.LoserGoals = team0Goals;
                    }
                    else
                    {
                        match.WinnerGoals = team0Goals;
                        match.LoserGoals = team1Goals;
                    }
                    Teams.Find(x => x.Name == match.Teams[coinFlip].Name).MatchesWon++;
                }
                else
                {
                    match.Winner = match.Teams[1].Name;
                    match.Loser = match.Teams[0].Name;
                    match.WinnerGoals = team1Goals;
                    match.LoserGoals = team0Goals;
                    Teams.Find(x => x.Name == match.Teams[1].Name).MatchesWon++;
                }
            }

            MatchesPlayed++;
        }

        int ModelEvent(double currentTeamAttackLambda, double oppositeTeamDefenseLambda)
        {
            double alpha = Rand.NextDouble();
            int nextGoalTime = (int)((-Math.Log(alpha) / (currentTeamAttackLambda - oppositeTeamDefenseLambda)) * 23);
            return nextGoalTime;
        }
        #endregion
        #region Training the team
        public void TrainTeam()
        {
            if (PlayerBalance > 0)
            {
                double averageAttack = 0;
                double averageDefense = 0;
                foreach (var player in Teams[PlayerTeamIndex].Players)
                {
                    if (player is Forward)
                    {
                        player.Attack += 2;
                        player.Defense += 0.7;
                        (player as Forward).StrikePrecision += 0.01;
                    }
                    if (player is Defender)
                    {
                        player.Attack += 0.5;
                        player.Defense += 2;
                    }
                    if (player is Goalkeeper)
                    {
                        player.Attack += 0.2;
                        (player as Goalkeeper).ChanceOfSave += 0.01;
                    }
                    averageAttack += player.Attack;
                    averageDefense += player.Defense;
                }
                averageAttack /= 11;
                averageDefense /= 11;

                PlayerBalance -= 1000;
                Teams[PlayerTeamIndex].LambdaAttack = averageAttack;
                Teams[PlayerTeamIndex].LambdaDefense = averageDefense;
                //Call the method for updating the TrainingTab UI here
            }
        }
        #endregion
    }

}
