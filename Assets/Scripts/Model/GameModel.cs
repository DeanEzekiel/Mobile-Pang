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

        public Mode GameMode;

        public UIModel UI;
        #endregion

        #region Unity Callbacks
        private void Awake()
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            GameMode = Mode.Mobile;
#else
            GameMode = Mode.PC;
#endif
        }
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
        [ContextMenu("Reset Player Values")]
        private void ResetPlayer()
        {
            Player.Life = _initPlayer.Life;
            Player.Score = _initPlayer.Score;
            Player.Multiplier = _initPlayer.Multiplier;

            Player.Speed = _initPlayer.Speed;
            Player.ShootCooldown = _initPlayer.ShootCooldown;
            Player.IsProtected = _initPlayer.IsProtected;
            Player.IsPlaying = _initPlayer.IsPlaying;
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
            Player.Multiplier++;
        }
        public void ResetMultiplier()
        {
            Player.Multiplier = 0;
        }

        public void AddScore(int pointsEarned)
        {
            if(Player.Multiplier > 1)
            {
                pointsEarned *= Player.Multiplier;
            }

            Player.Score += (pointsEarned);
        }
        #endregion
    }
}