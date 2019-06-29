using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        #region ChampionshipTabUIElements
        public GameObject ChampionshipPanelLeft;
        public GameObject ChampionshipPanelRight;
        public GameObject ChampionshipPanelStats;
        public GameObject ChampionshipLabelStatsScores;
        public GameObject TeamsNames;
        public GameObject TeamsGoals;
        public GameObject Winners;

        public TextMeshProUGUI PlayerTeamName;
        public TextMeshProUGUI MatchesWon;
        public TextMeshProUGUI GoalsScored;
        public TextMeshProUGUI Saves;
        //public TextMeshProUGUI BestAttacker;
        //public TextMeshProUGUI FastestGoal;

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

            AssignChampionshipTabElements();
            AssignTrainingTabElements();

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
            //Left side
            ChampionshipPanelLeft = ChampionshipTab.transform.Find("PanelLeft").gameObject;
            ChampionshipPanelRight = ChampionshipTab.transform.Find("PanelRight").gameObject;

            TeamsNames = ChampionshipPanelLeft.transform.Find("TeamsNames").gameObject;
            TeamsGoals = ChampionshipPanelLeft.transform.Find("TeamsGoals").gameObject;
            Winners = ChampionshipPanelLeft.transform.Find("Winners").gameObject;

            for (int i = 0; i < 24; i++)
            {
                TeamsNamesList.Add(TeamsNames.transform.Find("Team" + i).GetComponent<TextMeshProUGUI>().text);
            }

            //Right side
            PlayerTeamName = ChampionshipPanelRight.transform.Find("LabelPlayerTeamName").GetComponent<TextMeshProUGUI>();
            PlayerTeamName.text = "Your team: " + GameManager.GM.Teams[GameManager.GM.PlayerTeamIndex].Name;

            ChampionshipPanelStats = ChampionshipPanelRight.transform.Find("PanelStats").gameObject;
            ChampionshipLabelStatsScores = ChampionshipPanelStats.transform.Find("LabelStatsScores").gameObject;

            MatchesWon = ChampionshipLabelStatsScores.transform.Find("MatchesWon").GetComponent<TextMeshProUGUI>();
            GoalsScored = ChampionshipLabelStatsScores.transform.Find("GoalsScored").GetComponent<TextMeshProUGUI>();
            Saves = ChampionshipLabelStatsScores.transform.Find("Saves").GetComponent<TextMeshProUGUI>();
            //BestAttacker = ChampionshipLabelStatsScores.transform.Find("BestAttacker").GetComponent<TextMeshProUGUI>();
            //FastestGoal = ChampionshipLabelStatsScores.transform.Find("FastestGoal").GetComponent<TextMeshProUGUI>();
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
                        GameManager.GM.CreateMatch(TeamsNamesList[i], TeamsNamesList[i + 1]);
                    }
                    break;
                case 4:
                    for (int i = 8; i < 16; i += 2)
                    {
                        GameManager.GM.CreateMatch(TeamsNamesList[i], TeamsNamesList[i + 1]);

                    }
                    break;
                case 8:
                    for (int i = 16; i < 22; i += 2)
                    {
                        GameManager.GM.CreateMatch(TeamsNamesList[i], TeamsNamesList[i + 1]);
                    }
                    break;
                case 11:
                    GameManager.GM.CreateMatch(TeamsNamesList[22], TeamsNamesList[23]);
                    break;
            }
        }
        public void PlayMatch()
        {
            int currentMatchIndex = GameManager.GM.MatchesPlayed;
            if (currentMatchIndex == 0 || currentMatchIndex == 4 || currentMatchIndex == 8 || currentMatchIndex == 11)
            {
                AddNewMatches(currentMatchIndex);
            }
            GameManager.GM.PlayMatch(GameManager.GM.Matches[currentMatchIndex]);

            UpdateChampionshipBracket(currentMatchIndex);
            UpdateChampionshipPlayerTeamTab();
        }
        void UpdateChampionshipBracket(int lastMatchIndex)
        {
            switch (lastMatchIndex)
            {
                case 0:
                    TeamsGoals.transform.Find("MatchScore" + 0).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Goals.Where(x => x.TeamName == TeamsNamesList[0]).Count().ToString();
                    TeamsGoals.transform.Find("MatchScore" + 1).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Goals.Where(x => x.TeamName == TeamsNamesList[1]).Count().ToString();
                    TeamsNames.transform.Find("Team" + 8).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Loser;
                    TeamsNames.transform.Find("Team" + 12).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Winner;
                    TeamsNamesList[8] = GameManager.GM.Matches[lastMatchIndex].Loser;
                    TeamsNamesList[12] = GameManager.GM.Matches[lastMatchIndex].Winner;
                    break;
                case 1:
                    TeamsGoals.transform.Find("MatchScore" + 2).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Goals.Where(x => x.TeamName == TeamsNamesList[2]).Count().ToString();
                    TeamsGoals.transform.Find("MatchScore" + 3).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Goals.Where(x => x.TeamName == TeamsNamesList[3]).Count().ToString();
                    TeamsNames.transform.Find("Team" + 9).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Loser;
                    TeamsNames.transform.Find("Team" + 13).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Winner;
                    TeamsNamesList[9] = GameManager.GM.Matches[lastMatchIndex].Loser;
                    TeamsNamesList[13] = GameManager.GM.Matches[lastMatchIndex].Winner;
                    break;
                case 2:
                    TeamsGoals.transform.Find("MatchScore" + 4).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Goals.Where(x => x.TeamName == TeamsNamesList[4]).Count().ToString();
                    TeamsGoals.transform.Find("MatchScore" + 5).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Goals.Where(x => x.TeamName == TeamsNamesList[5]).Count().ToString();
                    TeamsNames.transform.Find("Team" + 10).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Loser;
                    TeamsNames.transform.Find("Team" + 14).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Winner;
                    TeamsNamesList[10] = GameManager.GM.Matches[lastMatchIndex].Loser;
                    TeamsNamesList[14] = GameManager.GM.Matches[lastMatchIndex].Winner;
                    break;
                case 3:
                    TeamsGoals.transform.Find("MatchScore" + 6).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Goals.Where(x => x.TeamName == TeamsNamesList[6]).Count().ToString();
                    TeamsGoals.transform.Find("MatchScore" + 7).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Goals.Where(x => x.TeamName == TeamsNamesList[7]).Count().ToString();
                    TeamsNames.transform.Find("Team" + 11).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Loser;
                    TeamsNames.transform.Find("Team" + 15).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Winner;
                    TeamsNamesList[11] = GameManager.GM.Matches[lastMatchIndex].Loser;
                    TeamsNamesList[15] = GameManager.GM.Matches[lastMatchIndex].Winner;
                    break;
                case 4:
                    TeamsGoals.transform.Find("MatchScore" + 8).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Goals.Where(x => x.TeamName == TeamsNamesList[8]).Count().ToString();
                    TeamsGoals.transform.Find("MatchScore" + 9).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Goals.Where(x => x.TeamName == TeamsNamesList[9]).Count().ToString();
                    TeamsNames.transform.Find("Team" + 16).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Winner;
                    TeamsNamesList[16] = GameManager.GM.Matches[lastMatchIndex].Winner;
                    break;
                case 5:
                    TeamsGoals.transform.Find("MatchScore" + 10).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Goals.Where(x => x.TeamName == TeamsNamesList[10]).Count().ToString();
                    TeamsGoals.transform.Find("MatchScore" + 11).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Goals.Where(x => x.TeamName == TeamsNamesList[11]).Count().ToString();
                    TeamsNames.transform.Find("Team" + 18).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Winner;
                    TeamsNamesList[18] = GameManager.GM.Matches[lastMatchIndex].Winner;
                    break;
                case 6:
                    TeamsGoals.transform.Find("MatchScore" + 12).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Goals.Where(x => x.TeamName == TeamsNamesList[12]).Count().ToString();
                    TeamsGoals.transform.Find("MatchScore" + 13).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Goals.Where(x => x.TeamName == TeamsNamesList[13]).Count().ToString();
                    TeamsNames.transform.Find("Team" + 17).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Loser;
                    TeamsNames.transform.Find("Team" + 20).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Winner;
                    TeamsNamesList[17] = GameManager.GM.Matches[lastMatchIndex].Loser;
                    TeamsNamesList[20] = GameManager.GM.Matches[lastMatchIndex].Winner;
                    break;
                case 7:
                    TeamsGoals.transform.Find("MatchScore" + 14).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Goals.Where(x => x.TeamName == TeamsNamesList[14]).Count().ToString();
                    TeamsGoals.transform.Find("MatchScore" + 15).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Goals.Where(x => x.TeamName == TeamsNamesList[15]).Count().ToString();
                    TeamsNames.transform.Find("Team" + 19).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Loser;
                    TeamsNames.transform.Find("Team" + 21).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Winner;
                    TeamsNamesList[19] = GameManager.GM.Matches[lastMatchIndex].Loser;
                    TeamsNamesList[21] = GameManager.GM.Matches[lastMatchIndex].Winner;
                    break;
                case 8:
                    TeamsGoals.transform.Find("MatchScore" + 16).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Goals.Where(x => x.TeamName == TeamsNamesList[16]).Count().ToString();
                    TeamsGoals.transform.Find("MatchScore" + 17).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Goals.Where(x => x.TeamName == TeamsNamesList[17]).Count().ToString();
                    TeamsNames.transform.Find("Team" + 22).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Winner;
                    TeamsNamesList[22] = GameManager.GM.Matches[lastMatchIndex].Winner;
                    break;
                case 9:
                    TeamsGoals.transform.Find("MatchScore" + 18).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Goals.Where(x => x.TeamName == TeamsNamesList[18]).Count().ToString();
                    TeamsGoals.transform.Find("MatchScore" + 19).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Goals.Where(x => x.TeamName == TeamsNamesList[19]).Count().ToString();
                    TeamsNames.transform.Find("Team" + 23).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Winner;
                    TeamsNamesList[23] = GameManager.GM.Matches[lastMatchIndex].Winner;
                    break;
                case 10:
                    TeamsGoals.transform.Find("MatchScore" + 20).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Goals.Where(x => x.TeamName == TeamsNamesList[20]).Count().ToString();
                    TeamsGoals.transform.Find("MatchScore" + 21).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Goals.Where(x => x.TeamName == TeamsNamesList[21]).Count().ToString();
                    if (GameManager.GM.Matches[lastMatchIndex].Goals.Where(x => x.TeamName == TeamsNamesList[20]).Count() > GameManager.GM.Matches[lastMatchIndex].Goals.Where(x => x.TeamName == TeamsNamesList[21]).Count())
                    {
                        Winners.transform.Find("1st").GetComponent<TextMeshProUGUI>().text = "1st place!";
                        Winners.transform.Find("2nd").GetComponent<TextMeshProUGUI>().text = "2nd place";
                    }
                    else
                    {
                        Winners.transform.Find("2nd").GetComponent<TextMeshProUGUI>().text = "1st place!";
                        Winners.transform.Find("1st").GetComponent<TextMeshProUGUI>().text = "2nd place";
                    }
                    break;
                case 11:
                    TeamsGoals.transform.Find("MatchScore" + 22).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Goals.Where(x => x.TeamName == TeamsNamesList[22]).Count().ToString();
                    TeamsGoals.transform.Find("MatchScore" + 23).GetComponent<TextMeshProUGUI>().text = GameManager.GM.Matches[lastMatchIndex].Goals.Where(x => x.TeamName == TeamsNamesList[23]).Count().ToString();
                    if (GameManager.GM.Matches[lastMatchIndex].Goals.Where(x => x.TeamName == TeamsNamesList[22]).Count() > GameManager.GM.Matches[lastMatchIndex].Goals.Where(x => x.TeamName == TeamsNamesList[23]).Count())
                    {
                        Winners.transform.Find("3rd").GetComponent<TextMeshProUGUI>().text = "3rd place";
                        Winners.transform.Find("4th").GetComponent<TextMeshProUGUI>().text = "4th place";
                    }
                    else
                    {
                        Winners.transform.Find("3rd").GetComponent<TextMeshProUGUI>().text = "4th place";
                        Winners.transform.Find("4th").GetComponent<TextMeshProUGUI>().text = "3rd place";
                    }
                    break;
            }
        }
        void UpdateChampionshipPlayerTeamTab()
        {
            MatchesWon.text = GameManager.GM.Teams[GameManager.GM.PlayerTeamIndex].MatchesWon.ToString();
            GoalsScored.text = GameManager.GM.Teams[GameManager.GM.PlayerTeamIndex].GoalsScored.ToString();
            Saves.text = GameManager.GM.Teams[GameManager.GM.PlayerTeamIndex].Saves.ToString();
        }

        public void TrainTeam()
        {
            GameManager.GM.TrainTeam();
            UpdateTrainingTabLabels();
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