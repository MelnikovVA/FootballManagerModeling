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
        public TMP_InputField ManagerFirstNameInput;
        public TMP_InputField ManagerLastNameInput;
        public GameObject PanelStart;
        public TMP_Dropdown TeamDropdown;
        public Button StartButton;
        #endregion
        #region MainMenuTabUIElements
        public GameObject ChampionshipPanelLeft;
        public GameObject ChampionshipPanelRight;
        public GameObject TeamsNames;
        public GameObject TeamsGoals;
        public GameObject Winners;

        public List<string> TeamsNamesList = new List<string>();
        #endregion
        #region TrainingTabUIElements
        public GameObject LabelValuesTraining;
        public Button ButtonTraining;
        public TextMeshProUGUI AvgAttackLabel;
        public TextMeshProUGUI AvgDefenseLabel;
        public TextMeshProUGUI PlayerBalance;
        #endregion

        private void Awake()
        {
            UIM = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            AssignCanvasVariables();
            AssignStartTabElements();
            AssignChampionshipTabElements();
            AssignTrainingTabElements();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void StartGame()
        {
            string playerFirstName = ManagerFirstNameInput.text;
            string playerLastName = ManagerLastNameInput.text;
            int chosenTeam = TeamDropdown.value;
            GameManager.GM.CreateTeams();
            GameManager.GM.GetManagerInfo(playerFirstName, playerLastName, chosenTeam);
            OpenMainTab();
        }

        #region OpeningTabs
        public void OpenMainTab()
        {
            MainMenuTab.gameObject.SetActive(true);

            StartTab.gameObject.SetActive(false);
            ChampionshipTab.gameObject.SetActive(false);
            TrainingTab.gameObject.SetActive(false);
            TeamTab.gameObject.SetActive(false);
            ManagerTab.gameObject.SetActive(false);
        }
        public void OpenChampionshipTab()
        {
            ChampionshipTab.gameObject.SetActive(true);

            StartTab.gameObject.SetActive(false);
            MainMenuTab.gameObject.SetActive(false);
            TrainingTab.gameObject.SetActive(false);
            TeamTab.gameObject.SetActive(false);
            ManagerTab.gameObject.SetActive(false);
        }
        public void OpenTrainingTab()
        {
            TrainingTab.gameObject.SetActive(true);

            StartTab.gameObject.SetActive(false);
            ChampionshipTab.gameObject.SetActive(false);
            MainMenuTab.gameObject.SetActive(false);
            TeamTab.gameObject.SetActive(false);
            ManagerTab.gameObject.SetActive(false);

            UpdateTrainingTabLabels();
        }
        public void OpenTeamTab()
        {
            TeamTab.gameObject.SetActive(true);

            StartTab.gameObject.SetActive(false);
            ChampionshipTab.gameObject.SetActive(false);
            MainMenuTab.gameObject.SetActive(false);
            TrainingTab.gameObject.SetActive(false);
            ManagerTab.gameObject.SetActive(false);
        }
        public void OpenManagerTab()
        {
            ManagerTab.gameObject.SetActive(true);

            StartTab.gameObject.SetActive(false);
            ChampionshipTab.gameObject.SetActive(false);
            MainMenuTab.gameObject.SetActive(false);
            TrainingTab.gameObject.SetActive(false);
            TeamTab.gameObject.SetActive(false);
        }
        #endregion

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
        void AssignStartTabElements()
        {
            PanelStart = StartTab.transform.Find("PanelInfo").gameObject;
            StartButton = StartTab.transform.Find("ButtonStart").GetComponent<Button>();

            ManagerFirstNameInput = PanelStart.transform.Find("InputFirstName").GetComponent<TMP_InputField>();
            ManagerLastNameInput = PanelStart.transform.Find("InputLastName").GetComponent<TMP_InputField>();
            TeamDropdown = PanelStart.transform.Find("Dropdown").GetComponent<TMP_Dropdown>();
        }
        void AssignChampionshipTabElements()
        {
            ChampionshipPanelLeft = MainMenuTab.transform.Find("PanelLeft").gameObject;
            ChampionshipPanelRight = MainMenuTab.transform.Find("PanelRight").gameObject;

            TeamsNames = ChampionshipPanelLeft.transform.Find("TeamsNames").gameObject;
            TeamsGoals = ChampionshipPanelLeft.transform.Find("TeamsGoals").gameObject;

            for (int i = 0; i < 24; i++)
            {
                TeamsNamesList.Add(TeamsNames.transform.Find("Team" + i).GetComponent<TextMeshProUGUI>().text);
            }
        }
        void AssignTrainingTabElements()
        {
            LabelValuesTraining = TrainingTab.transform.Find("LabelValues").gameObject;

            AvgAttackLabel = LabelValuesTraining.transform.Find("AvgAttack").GetComponent<TextMeshProUGUI>();
            AvgDefenseLabel = LabelValuesTraining.transform.Find("AvgDefense").GetComponent<TextMeshProUGUI>();
            PlayerBalance = LabelValuesTraining.transform.Find("PlayerBalance").GetComponent<TextMeshProUGUI>();
        }
        #endregion

        #region Game events
        void AddNewMatches(int currentMatchIndex)
        {
            switch (currentMatchIndex)
            {
                case 0:
                    for (int i = 0; i < 8; i += 2)
                    {
                        GameManager.GM.Matches.Add(new Match(GameManager.GM.Teams.Find(x => x.Name == TeamsNamesList[i]),
                            GameManager.GM.Teams.Find(x => x.Name == TeamsNamesList[i + 1])));
                    }
                    break;
                case 4:
                    for (int i = 8; i < 16; i += 2)
                    {
                        GameManager.GM.Matches.Add(new Match(GameManager.GM.Teams.Find(x => x.Name == TeamsNamesList[i]),
                            GameManager.GM.Teams.Find(x => x.Name == TeamsNamesList[i + 1])));
                    }
                    break;
                case 8:
                    for (int i = 16; i < 22; i += 2)
                    {
                        GameManager.GM.Matches.Add(new Match(GameManager.GM.Teams.Find(x => x.Name == TeamsNamesList[i]),
                            GameManager.GM.Teams.Find(x => x.Name == TeamsNamesList[i + 1])));
                    }
                    break;
                case 11:
                    GameManager.GM.Matches.Add(new Match(GameManager.GM.Teams.Find(x => x.Name == TeamsNamesList[22]),
                            GameManager.GM.Teams.Find(x => x.Name == TeamsNamesList[23])));
                    break;
            }
        }
        public void TrainTeam()
        {
            GameManager.GM.TrainTeam();
            UpdateTrainingTabLabels();
        }  
        public void PlayMatch()
        {
            int currentMatchIndex = GameManager.GM.MatchesPlayed;
            if (currentMatchIndex == 0 || currentMatchIndex == 4 || currentMatchIndex == 8 || currentMatchIndex == 11)
            {
                AddNewMatches(currentMatchIndex);
            }
            

        }
        #endregion

        public void UpdateTrainingTabLabels()
        {
            AvgAttackLabel.text = GameManager.GM.Teams[GameManager.GM.PlayerTeamIndex].LambdaAttack.ToString("F2");
            AvgDefenseLabel.text = GameManager.GM.Teams[GameManager.GM.PlayerTeamIndex].LambdaDefense.ToString("F2");
            PlayerBalance.text = GameManager.GM.PlayerBalance.ToString();
        }
    }
}