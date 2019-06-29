using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FootballManagerModeling
{
    public interface IPlayer
    {
        string Name { get; set; }
        double Attack { get; set; }
        double Defense { get; set; }
    }
}