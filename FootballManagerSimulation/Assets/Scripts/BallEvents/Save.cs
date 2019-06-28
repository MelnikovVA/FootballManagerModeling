using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FootballManagerModeling
{
    public class Save : IBallEvent
    {
        public int EventTime { get; set; }
        public IPlayer Player { get; set; }

        Save(int time, Goalkeeper goalkeeper)
        {
            this.EventTime = time;
            this.Player = goalkeeper;
        }
    }
}