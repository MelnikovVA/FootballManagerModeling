using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace FootballManagerModeling
{
    public class Match
    {
        System.Random rand = new System.Random();

        public List<FootballTeam> Teams = new List<FootballTeam>();
        public List<int> TimeSinceAllEvents = new List<int> { 0, 0 };
        public List<int> TillNextEvent = new List<int> { 0, 0 };
        public List<int> Goals = new List<int> { 0, 0 };
        public List<int> Saves = new List<int> { 0, 0 };

        public int Winner;
        public int Loser;
        public int WinnerGoals;
        public int WinnerSaves;
        public int LoserGoals;
        public int LoserSaves;

        public Match(FootballTeam team1, FootballTeam team2)
        {
            Teams.Add(team1);
            Teams.Add(team2);
        }
    }
}