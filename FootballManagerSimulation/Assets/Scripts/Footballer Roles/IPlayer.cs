using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FootballManagerModeling
{
    public enum Role
    {
        Defender,
        Forward,
        Goalkeeper
    }

    public interface IPlayer
    {
        string Name { get; set; }
        Role Role { get; set; }
        double Attack { get; set; }
        double Defense { get; set; }
    }
}