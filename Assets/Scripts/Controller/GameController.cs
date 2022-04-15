using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobilePang
{
    public class GameController : MVCHelper
    {
        #region Controllers
        [SerializeField]
        private PlayerController Player;
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
        #endregion
    }
}