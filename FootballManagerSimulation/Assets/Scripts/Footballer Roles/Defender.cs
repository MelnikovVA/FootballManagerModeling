using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace FootballManagerModeling
{
    public class Defender : MonoBehaviour, IPlayer
    {
        public static System.Random rand = new System.Random();
        public string Name { get; set; }
        public double Attack { get; set; }
        public double Defense { get; set; }

        public Defender(string name)
        {
            this.Name = name;
            this.Attack = rand.Next(5, 20);
            this.Defense = rand.Next(30, 50);
        }
    }
}