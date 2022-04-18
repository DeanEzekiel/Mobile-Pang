using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MobilePang;
using MobilePang.View;
using System;

namespace MobilePang.Controller
{
    public class UIController : MVCHelper
    {
        #region Events
        public static event Action MoveBalls;
        public static event Action ReleaseMobileButtons;
        #endregion

        #region Unity Callbacks
        private void Awake()
        {
            DeactivateAllPanels();
            Model.UI.MainMenu.Activate();
        }
        #endregion

        #region Implementation
        private void DeactivateAllPanels()
        {
            Model.UI.MainMenu.Deactivate();
            Model.UI.LevelMenu.Deactivate();
            Model.UI.GamePlayHUD.Deactivate();
            Model.UI.PausedPanel.Deactivate();
            Model.UI.LevelStartPanel.Deactivate();
            Model.UI.LevelClearedPanel.Deactivate();
            Model.UI.LevelFailedPanel.Deactivate();
            Model.UI.GameOverPanel.Deactivate();

            Model.UI.MobileControlsUI.Deactivate();
            Model.UI.KeyboardControlsUI.Deactivate();

            Model.UI.Game.SetActive(false);
        }

        public void OpenLevelMenu()
        {
            DeactivateAllPanels();
            Model.UI.LevelMenu.Activate();
        }

        public void OnQuitGame()
        {
            Controller.ExitGame();
        }

        private void SetControlsView()
        {
            if (Model.GameMode == Mode.Mobile)
            {
                Model.UI.MobileControlsUI.Activate();
            }
            else
            {
                Model.UI.KeyboardControlsUI.Activate();
            }
        }

        private void ResetPool()
        {
            Model.BallPool.ResetPool();
            Model.AmmoPool.ResetPool();
        }

        public void OnStartLevel(int level)
        {
            ResetPool();
            Controller.Level.SetLevel(level);
            Controller.Level.StartLevel();
            Controller.Time.ResetTimer();

            Controller.Time.FreezeTimer();
            Controller.HaltPlaying();

            DeactivateAllPanels();
            Model.UI.Game.SetActive(true);

            Model.UI.LevelStartPanel.Activate();
            Model.UI.LevelStartPanel.WaitThenStartGame();

            SetControlsView();
        }

        public void OnRestartCurrentLevel()
        {
            ResetPool();
            Controller.Level.StartLevel();
            Controller.Time.ResetTimer();

            Controller.Time.FreezeTimer();
            Controller.HaltPlaying();

            DeactivateAllPanels();
            Model.UI.Game.SetActive(true);

            Model.UI.LevelStartPanel.Activate();
            Model.UI.LevelStartPanel.WaitThenStartGame();

            SetControlsView();
        }

        public void OnNextLevel()
        {
            ResetPool();
            if (Model.Level.CurrentLevel < Model.Level.Levels.Count)
            {
                Controller.Level.NextLevel();
                Controller.Time.ResetTimer();

                Controller.Time.FreezeTimer();
                Controller.HaltPlaying();

                DeactivateAllPanels();
                Model.UI.Game.SetActive(true);

                Model.UI.LevelStartPanel.Activate();
                Model.UI.LevelStartPanel.WaitThenStartGame();

                SetControlsView();
            }
            else
            {
                Debug.Log("No further level.");
            }
        }

        public void OnPreviousLevel()
        {
            ResetPool();
            if (Model.Level.CurrentLevel > 1)
            {
                Controller.Level.PreviousLevel();
                Controller.Time.ResetTimer();

                Controller.Time.FreezeTimer();
                Controller.HaltPlaying();

                DeactivateAllPanels();
                Model.UI.Game.SetActive(true);

                Model.UI.LevelStartPanel.Activate();
                Model.UI.LevelStartPanel.WaitThenStartGame();

                SetControlsView();
            }
            else
            {
                Debug.Log("No further level.");
            }
        }

        public void ActualStartGame()
        {
            Controller.Time.StartTimer();
            Controller.StartPlaying();

            Model.UI.GamePlayHUD.Activate();

            UpdateHUDLives();
            UpdateHUDScore();

            MoveBalls?.Invoke();
        }

        public void OnPause()
        {
            ReleaseMobileButtons?.Invoke();

            Controller.PauseGame();
            Model.UI.PausedPanel.Activate();
        }

        public void OnResume()
        {
            Controller.ResumeGame();
            Model.UI.PausedPanel.Deactivate();
        }

        public void OnExitToMainMenu()
        {
            DeactivateAllPanels();
            Model.UI.MainMenu.Activate();

            Controller.ResetPlayerModel();
            Controller.ResumeGame(); // to set time scale back to 1

            Controller.Level.DeactivateLevels();
        }

        public void OnLevelCleared()
        {
            ReleaseMobileButtons?.Invoke();

            DeactivateAllPanels();
            Model.UI.LevelClearedPanel.Activate();
            UpdateLevelClearBoard();
        }

        public void OnLevelFailed()
        {
            ReleaseMobileButtons?.Invoke();

            DeactivateAllPanels();
            Model.UI.LevelFailedPanel.Activate();
            Model.UI.LevelFailedPanel.WaitThenRestartLevel();
        }

        public void OnGameOver()
        {
            ReleaseMobileButtons?.Invoke();

            DeactivateAllPanels();
            Model.UI.GameOverPanel.Activate();
            UpdateGameOverBoard();
        }

        public void UpdateHUDLives()
        {
            Model.UI.HUDLives.text = Model.Player.Life.ToString();
        }
        public void UpdateHUDScore()
        {
            Model.UI.HUDScore.text = Model.Player.Score.ToString();
        }
        public void UpdateLevelClearBoard()
        {
            Model.UI.LevelClearBoard.text = $"Score: {Model.Player.Score}\n" +
                $"Lives Left: {Model.Player.Life}";
        }
        public void UpdateGameOverBoard()
        {
            Model.UI.GameOverBoard.text = $"Final Score: {Model.Player.Score}\n" +
                $"Level Reached: {Model.Level.CurrentLevel}";
        }
        #endregion
    }
}