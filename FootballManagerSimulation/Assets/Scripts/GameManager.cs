using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FootballManagerModeling
{

    public class GameManager : MonoBehaviour
    {
        public static GameManager GM;
        public static Random Rand = new Random();

        public List<FootballTeam> Teams = new List<FootballTeam>();
        public List<Match> Matches = new List<Match>();


        private void Awake()
        {
            GM = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        void CreateTeams()
        {
            for (int i=0; i<8; i++)
            {
                Teams.Add(new FootballTeam(i));
            }
        }

       
        
    }
    #region Playing a match
    #endregion
}
