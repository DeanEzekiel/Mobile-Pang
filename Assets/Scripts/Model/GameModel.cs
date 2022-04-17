using System.Collections;
using System.Collections.Generic;
using MobilePang.Controller;
using UnityEngine;
using MobilePang;

namespace MobilePang.Model
{
    public class GameModel : MVCHelper
    {
        #region Fields
        [SerializeField]
        private int _score = 0;
        private int _multiplier = 0;
        public const float StreakSec = 1f;

        [Tooltip("needed to determine if the multiplier sets back to 0 or adds 1")]
        public float LastHitTime = 0f;
        #endregion

        #region Models & Scriptables
        public TimeModel Time;

        public LevelModel Level;

        [Header("Player Data")]
        public PlayerModel_SO Player;
        [SerializeField]
        private PlayerModel_SO _initPlayer;

        [Header("Pool")]
        [SerializeField]
        private PoolModelSO _poolSize;
        [Space]
        public BallPoolModel BallPool;
        [Space]
        public AmmoPoolModel AmmoPool;

        [Header("Ball Models")]
        [SerializeField]
        private BallModel_SO _largeBall;
        [SerializeField]
        private BallModel_SO _mediumBall;
        [SerializeField]
        private BallModel_SO _smallBall;
        [SerializeField]
        private BallModel_SO _xSmallBall;

        [Header("Ammo Data")]
        [SerializeField]
        private AmmoModel_SO Ammo;

        [Header("Ball Force")]
        [SerializeField]
        public float BallSlowFactor = 0.3f;
        #endregion

        #region Unity Callbacks
        private void OnEnable()
        {
            GameController.ResetPlayer += ResetPlayer;
        }

        private void OnDisable()
        {
            GameController.ResetPlayer -= ResetPlayer;
        }
        #endregion

        #region Implementation
        private void ResetPlayer()
        {
            Player.Life = _initPlayer.Life;
            Player.Speed = _initPlayer.Speed;
            Player.ShootCooldown = _initPlayer.ShootCooldown;
            Player.IsProtected = _initPlayer.IsProtected;
        }

        public int GetPoolSize(PoolableObject @object)
        {
            switch (@object)
            {
                case PoolableObject.Ammo:
                    return _poolSize.Ammos;
                case PoolableObject.Ball:
                    return _poolSize.Balls;
                default:
                    return 0;
            }
        }

        public BallModel_SO GetBallTemplate(BallType ballType)
        {
            switch (ballType)
            {
                case BallType.Large:
                    return _largeBall;
                case BallType.Medium:
                    return _mediumBall;
                case BallType.Small:
                    return _smallBall;
                case BallType.XSmall:
                    return _xSmallBall;
                default:
                    return null;
            }
        }

        public BallType GetNextBallType(BallType ballType)
        {
            switch (ballType)
            {
                case BallType.Large:
                    return BallType.Medium;
                case BallType.Medium:
                    return BallType.Small;
                case BallType.Small:
                    return BallType.XSmall;
                default:
                    return BallType.None;
            }
        }

        public AmmoModel_SO GetAmmo()
        {
            return Ammo;
        }

        public void AddMultiplier()
        {
            _multiplier++;
        }
        public void ResetMultiplier()
        {
            _multiplier = 0;
        }

        public void AddScore(int pointsEarned)
        {
            if(_multiplier > 1)
            {
                pointsEarned *= _multiplier;
            }

            _score += (pointsEarned);
        }
        #endregion
    }
}