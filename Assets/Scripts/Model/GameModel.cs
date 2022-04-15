using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobilePang
{
    public class GameModel : MVCHelper
    {
        #region Models
        public PlayerModel Player;
        [SerializeField]
        private PlayerModel _player;
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
            Player.Life = _player.Life;
            Player.Speed = _player.Speed;
            Player.ShootCooldown = _player.ShootCooldown;
            Player.IsProtected = _player.IsProtected;
        }
        #endregion
    }
}