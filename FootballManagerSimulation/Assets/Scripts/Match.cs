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
        public List<Goal> Goals = new List<Goal>();
        public List<Save> Saves = new List<Save>();

        public string Winner;
        public string Loser;
        public int WinnerGoals;
        public int LoserGoals;

        public Match(FootballTeam team1, FootballTeam team2)
        {
            Teams.Add(team1);
            Teams.Add(team2);
        }
    }
}