using System.Collections;
using System.Collections.Generic;
using MobilePang.Controller;
using UnityEngine;
using MobilePang;

namespace MobilePang.Model
{
    public class TimeModel : MVCHelper
    {
        [Header("Time Data")]
        public TimeModel_SO Timer;
        [SerializeField]
        private TimeModel_SO _initTimer;

        public void ResetTimer()
        {
            Timer.TimeRemaining = _initTimer.TimeRemaining;
            Timer.IsTimeTicking = _initTimer.IsTimeTicking;
        }

        public void FreezeTimer()
        {
            Timer.IsTimeTicking = false;
        }

        public void StartTimer()
        {
            Timer.IsTimeTicking = true;
        }
    }
}