using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FootballManagerModeling
{
    public interface IBallEvent
    {
        int EventTime { get; set; }
        IPlayer Player { get; set; }
    }
}