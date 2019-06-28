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
        void AssignTrainingTabElements()
        {
            LabelValuesTraining = TrainingTab.transform.Find("LabelValues").gameObject;

            AvgAttackLabel = LabelValuesTraining.transform.Find("AvgAttack").GetComponent<TextMeshProUGUI>();
            AvgDefenseLabel = LabelValuesTraining.transform.Find("AvgDefense").GetComponent<TextMeshProUGUI>();
            PlayerBalance = LabelValuesTraining.transform.Find("PlayerBalance").GetComponent<TextMeshProUGUI>();
        }
        #endregion

        #region Game events
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