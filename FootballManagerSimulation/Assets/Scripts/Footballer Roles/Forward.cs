using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace FootballManagerModeling
{
    public class Forward : MonoBehaviour, IPlayer
    {
        public static System.Random rand = new System.Random();
        public string Name { get; set; }
        public Role Role { get; set; }
        public double Attack { get; set; }
        public double Defense { get; set; }
        public double StrikePrecision;

        public Forward(string name)
        {
            this.Name = name;
            this.Role = Role.Forward;
            this.Attack = rand.Next(50, 80);
            this.Defense = rand.Next(0, 20);
            this.StrikePrecision = rand.NextDouble();

            if (StrikePrecision < 0.5)
                StrikePrecision += 0.5;
        }

        public bool TryToStrike()
        {
            double randomStrike = rand.NextDouble();
            if (StrikePrecision > randomStrike)
                return true;
            return false;
        }
    }
}