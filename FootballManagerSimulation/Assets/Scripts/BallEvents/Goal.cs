using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FootballManagerModeling
{
    public class Goal : IBallEvent
    {
        public int EventTime { get; set; }
        public IPlayer Player { get; set; }
        public string TeamName { get; set; }

        Goal(int time, string teamName, Forward forward)
        {
            this.EventTime = time;
            this.Player = forward;
            this.TeamName = teamName;
        }
    }
}