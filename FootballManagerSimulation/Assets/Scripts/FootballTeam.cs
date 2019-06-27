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
        public double Lambda;
        public int GoalsScored = 0;
        public int MatchesWon = 0;
        public int Saves = 0;
        public double TotalAttack = 0;
        public double TotalDefense = 0;

        public FootballTeam(string Name)
        {
            switch (Name)
            {
                case "Belgium":
                    PlayersNames = DataProvider.PlayersBelgium;
                    break;
                case "Brazil":
                    PlayersNames = DataProvider.PlayersBrazil;
                    break;
                case "England":
                    PlayersNames = DataProvider.PlayersEngland;
                    break;
                case "France":
                    PlayersNames = DataProvider.PlayersFrance;
                    break;
                case "Germany":
                    PlayersNames = DataProvider.PlayersGermany;
                    break;
                case "Portugal":
                    PlayersNames = DataProvider.PlayersPortugal;
                    break;
                case "Russia":
                    PlayersNames = DataProvider.PlayersRussia;
                    break;
                case "Spain":
                    PlayersNames = DataProvider.PlayersSpain;
                    break;
            }

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

            
        }
    }
}