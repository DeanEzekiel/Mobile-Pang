using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MobilePang;

namespace MobilePang.Controller
{
    public class GameController : MVCHelper
    {
        #region Controllers
        [SerializeField]
        private PlayerController Player;
        public AmmoController Ammo;
        public BallController Ball;
        public TimeController Time;
        public LevelController Level;
        public UIController UI;
        #endregion

        #region Events
        public static event Action ResetPlayer;
        #endregion

        #region Unity Callbacks
        private void Start()
        {
            ResetPlayerModel();
        }
        #endregion

        #region Implementation
        [ContextMenu("Reset Player Model")]
        public void ResetPlayerModel()
        {
            ResetPlayer?.Invoke();
        }

        public void AddPoints(int pointsEarned)
        {
            Model.AddScore(pointsEarned);
            Controller.UI.UpdateHUDScore();
        }

        public void DeductLife()
        {
            Model.Player.Life--;
            Controller.UI.UpdateHUDLives();
        }

        public void StartPlaying()
        {
            Player.StartPlaying();
        }
        public void HaltPlaying()
        {
            Player.HaltPlaying();
        }

        public void PauseGame()
        {
            UnityEngine.Time.timeScale = 0;
        }

        public void ResumeGame()
        {
            UnityEngine.Time.timeScale = 1;
        }

        public void ExitGame()
        {
            //End Game
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
            Application.OpenURL(webplayerQuitURL);
#else
            Application.Quit();
#endif
        }
        #endregion
    }
}