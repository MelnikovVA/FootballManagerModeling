using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace FootballManagerModeling
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager UIM;

        public Canvas StartTab, MainMenuTab, ChampionshipTab, TrainingTab, TeamTab, ManagerTab;

        #region StartTabUIElements
        public TMP_InputField ManagerFirstName;
        public TMP_InputField ManagerLastName;
        public Dropdown CountryDropdown;
        public Button StartButton;
        #endregion

        private void Awake()
        {
            UIM = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            AssignCanvasVariables();
        }

        // Update is called once per frame
        void Update()
        {

        }


        //public void OpenTab(string TabName)
        //{

        //}

        #region UIInitialization
        void AssignCanvasVariables()
        {
            StartTab = transform.Find("StartTab").GetComponent<Canvas>();
            MainMenuTab = transform.Find("MainMenuTab").GetComponent<Canvas>();
            ChampionshipTab = transform.Find("ChampionshipTab").GetComponent<Canvas>();
            TrainingTab = transform.Find("TrainingTab").GetComponent<Canvas>();
            TeamTab = transform.Find("TeamTab").GetComponent<Canvas>();
            ManagerTab = transform.Find("ManagerTab").GetComponent<Canvas>();
        }
        #endregion
    }
}