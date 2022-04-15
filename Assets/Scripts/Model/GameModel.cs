using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobilePang
{
    public class GameModel : MVCHelper
    {
        #region Models
        public PlayerModel_SO Player;
        [SerializeField]
        private PlayerModel_SO _initPlayer;
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
        #endregion
    }
}