using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace FootballManagerModeling
{
    public class FootballTeam : MonoBehaviour
    {
        public string Name;
        public List<IPlayer> Players = new List<IPlayer>();
        public List<string> PlayersNames;
        public Forward BestForward;
        public double LambdaAttack;
        public double LambdaDefense;
        public int GoalsScored = 0;
        public int MatchesWon = 0;
        public int Saves = 0;
        public int FastestGoal = 10000;
        public double TotalAttack = 0;
        public double TotalDefense = 0;

        public FootballTeam(int index)
        {
            switch (index)
            {
                case 0:
                    this.Name = "Belgium";
                    PlayersNames = DataProvider.PlayersBelgium;
                    break;
                case 1:
                    this.Name = "Brazil";
                    PlayersNames = DataProvider.PlayersBrazil;
                    break;
                case 2:
                    this.Name = "England";
                    PlayersNames = DataProvider.PlayersEngland;
                    break;
                case 3:
                    this.Name = "France";
                    PlayersNames = DataProvider.PlayersFrance;
                    break;
                case 4:
                    this.Name = "Germany";
                    PlayersNames = DataProvider.PlayersGermany;
                    break;
                case 5:
                    this.Name = "Portugal";
                    PlayersNames = DataProvider.PlayersPortugal;
                    break;
                case 6:
                    this.Name = "Russia";
                    PlayersNames = DataProvider.PlayersRussia;
                    break;
                case 7:
                    this.Name = "Spain";
                    PlayersNames = DataProvider.PlayersSpain;
                    break;
            }
        }
        public void AddPlayers()
        {
            for (int i = 0; i < 11; i++)
            {
                if (i < 5)
                    Players.Add(new Forward(PlayersNames[i]));
                else
                {
                    if (i < 10)
                        Players.Add(new Defender(PlayersNames[i]));
                    else
                        Players.Add(new Goalkeeper(PlayersNames[i]));
                }
                TotalAttack += Players[i].Attack;
                TotalDefense += Players[i].Defense;
            }
            LambdaAttack = TotalAttack / 11;
            LambdaDefense = TotalDefense / 11;
        }
    }
}