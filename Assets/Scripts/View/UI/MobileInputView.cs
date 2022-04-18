using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MobilePang;
using MobilePang.Controller;
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
        private void Awake()
        {
            _btnShoot.onClick.AddListener(OnShoot);
        }

        private void OnEnable()
        {
            UIController.ReleaseMobileButtons += ReleaseHold;
        }
        private void OnDisable()
        {
            UIController.ReleaseMobileButtons -= ReleaseHold;
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
        public void ReleaseHold()
        {
            _btnLeft.IsHeld = false;
            _btnRight.IsHeld = false;
        }
        private void OnShoot()
        {
            Shoot?.Invoke();
        }
        #endregion
    }
}