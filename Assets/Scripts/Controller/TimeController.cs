using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MobilePang;
using MobilePang.View;

namespace MobilePang.Controller
{
    public class TimeController : MVCHelper
    {
        #region Unity Callbacks
        private void Update()
        {
            Timer();
        }
        #endregion

        #region Implementation
        private void Timer()
        {
            if (Model.Time.Timer.IsTimeTicking)
            {
                if (Model.Time.Timer.TimeRemaining > 0)
                {
                    Model.Time.Timer.TimeRemaining -= Time.deltaTime;
                }
                else
                {
                    FreezeTimer();

                    Controller.DeductLife();
                    if (Model.Player.Life == 0)
                    {
                        Controller.UI.OnGameOver();
                    }
                    else
                    {
                        Controller.UI.OnLevelFailed();
                    }
                }
            }
        }

        [ContextMenu("Reset Timer")]
        public void ResetTimer()
        {
            Model.Time.ResetTimer();
        }

        [ContextMenu("Start Timer")]
        public void StartTimer()
        {
            Model.Time.StartTimer();
        }

        [ContextMenu("Freeze Timer")]
        public void FreezeTimer()
        {
            Model.Time.FreezeTimer();
        }

        public bool IsTimeTicking()
        {
            return Model.Time.Timer.IsTimeTicking;
        }

        #endregion
    }
}