using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FootballManagerModeling
{
    public class Save : IBallEvent
    {
        public int EventTime { get; set; }
        public IPlayer Player { get; set; }
        public string TeamName { get; set; }

        public Save(int time, string teamName, Goalkeeper goalkeeper)
        {
            this.EventTime = time;
            this.Player = goalkeeper;
            this.TeamName = teamName;
        }
    }
}