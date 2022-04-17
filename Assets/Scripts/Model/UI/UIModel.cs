using System.Collections;
using System.Collections.Generic;
using MobilePang.Controller;
using UnityEngine;
using MobilePang;
using MobilePang.View;
using UnityEngine.UI;
using TMPro;

namespace MobilePang.Model
{
    public class UIModel : MVCHelper
    {
        #region Fields
        public float WaitTime = 0.5f;

        public GameObject buttonPrefab;
        public Transform LevelButtonsContainer;

        #endregion

        #region Texts
        [Header("TextMesh")]
        public TextMeshProUGUI HUDLives;
        public TextMeshProUGUI HUDScore;
        public TextMeshProUGUI LevelClearBoard;
        public TextMeshProUGUI GameOverBoard;
        #endregion

        #region Panels / Containers
        [Header("Panels / Containers")]
        public UIView MainMenu;
        public UIView LevelMenu;
        [Space]
        public UIView GamePlayHUD;
        public UIView PausedPanel;
        public UIView LevelStartPanel;
        public UIView LevelClearedPanel;
        public UIView LevelFailedPanel;
        [Space]
        public UIView GameOverPanel;

        [Header("Controls UI")]
        public UIView MobileControlsUI;
        public UIView KeyboardControlsUI;

        [Header("The Game / Levels")]
        public GameObject Game;
        #endregion

        #region Buttons
        [Header("Buttons")]
        public Button MMLevels;
        public Button MMQuit;
        [Space]
        public Button LMBack;
        [Space]
        public Button GPPause;
        [Space]
        public Button PPResume;
        public Button PPExit;
        [Space]
        public Button LCPNextLevel;
        public Button LCPExit;
        [Space]
        public Button GOHome;
        #endregion

        #region Unity Callback - Button Implementation
        private void Start()
        {
            MMLevels.onClick.AddListener(Controller.UI.OpenLevelMenu);
            MMQuit.onClick.AddListener(Controller.UI.OnQuitGame);

            LMBack.onClick.AddListener(Controller.UI.OnExitToMainMenu);

            GPPause.onClick.AddListener(Controller.UI.OnPause);

            PPResume.onClick.AddListener(Controller.UI.OnResume);
            PPExit.onClick.AddListener(Controller.UI.OnExitToMainMenu);

            LCPNextLevel.onClick.AddListener(Controller.UI.OnNextLevel);
            LCPExit.onClick.AddListener(Controller.UI.OnExitToMainMenu);

            GOHome.onClick.AddListener(Controller.UI.OnExitToMainMenu);

            LevelButtons();
        }

        private void LevelButtons()
        {
            //clear the buttons inside the container
            foreach (Transform child in LevelButtonsContainer)
            {
                Destroy(child.gameObject);
            }

            for (int i = 0; i < Model.Level.Levels.Count; i++)
            {
                //instantiate buttons
                GameObject goButton = Instantiate(buttonPrefab) as GameObject;
                goButton.GetComponentInChildren<TextMeshProUGUI>().text =
                    $"{i + 1}";
                goButton.transform.SetParent(LevelButtonsContainer);

                int level = i + 1;
                goButton.GetComponent<Button>().onClick.AddListener(
                    () => Controller.UI.OnStartLevel(level)
                    );
            }
        }
        #endregion
    }
}