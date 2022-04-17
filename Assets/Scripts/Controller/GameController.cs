﻿using System;
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
        [SerializeField]
        public AmmoController Ammo;
        [SerializeField]
        public BallController Ball;
        [SerializeField]
        public TimeController Time;
        [SerializeField]
        public LevelController Level;
        #endregion

        #region Events
        public static event Action ResetPlayer;
        #endregion

        #region Unity Callbacks
        #endregion

        #region Implementation
        [ContextMenu("Reset Player Model")]
        private void ResetPlayerModel()
        {
            ResetPlayer?.Invoke();
        }

        public void AddPoints(int pointsEarned)
        {
            Model.AddScore(pointsEarned);
        }
        #endregion
    }
}