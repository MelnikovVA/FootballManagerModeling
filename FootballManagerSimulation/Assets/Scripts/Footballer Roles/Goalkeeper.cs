using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace FootballManagerModeling
{
    public class Goalkeeper : MonoBehaviour, IPlayer
    {
        public static System.Random rand = new System.Random();
        public string Name { get; set; }
        public double Attack { get; set; }
        public double Defense { get; set; }
        public double GoalProtection;
        public double ChanceOfSave;

        public Goalkeeper(string name)
        {
            this.Name = name;
            this.Attack = rand.Next(0, 10);
            this.Defense = 0;
            this.GoalProtection = rand.Next(20, 35);
            this.ChanceOfSave = GoalProtection / 100;
        }

        public bool TryToSave()
        {
            double randomSave = rand.NextDouble();
            if (ChanceOfSave > randomSave)
                return true;
            return false;
        }
    }
}
