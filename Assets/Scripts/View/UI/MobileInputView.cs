using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MobilePang;
using System;

namespace MobilePang.View
{
    public class MobileInputView : MVCHelper
    {
        #region Buttons
        [Header("Controls")]
        [SerializeField]
        private ButtonWithHold _btnLeft;
        [SerializeField]
        private ButtonWithHold _btnRight;
        [SerializeField]
        private Button _btnShoot;
        #endregion

        #region Events
        public static event Action<Direction> MoveToDirection;
        public static event Action Shoot;
        #endregion

        #region Unity Callbacks
        private void Start()
        {
            _btnShoot.onClick.AddListener(OnShoot);
        }

        private void FixedUpdate()
        {
            if (_btnLeft.IsHeld)
            {
                MoveToDirection?.Invoke(Direction.Left);
            }
            else if (_btnRight.IsHeld)
            {
                MoveToDirection?.Invoke(Direction.Right);
            }
        }
        #endregion

        #region Implementation
        private void OnShoot()
        {
            Shoot?.Invoke();
        }
        #endregion
    }
}