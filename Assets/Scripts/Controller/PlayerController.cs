using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MobilePang;
using MobilePang.View;

namespace MobilePang.Controller
{
    public class PlayerController : MVCHelper
    {
        #region Unity Callbacks

        private void OnEnable()
        {
            MobileInputView.MoveToDirection += MoveTo;
            MobileInputView.Shoot += Shoot;
        }

        private void OnDisable()
        {
            MobileInputView.MoveToDirection -= MoveTo;
            MobileInputView.Shoot -= Shoot;
        }

        private void FixedUpdate()
        {
            MovementControl();
        }

        #endregion

        #region Implementation
        private void MovementControl()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Shoot();
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                MoveTo(Direction.Left);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                MoveTo(Direction.Right);
            }
        }

        private void MoveTo(Direction direction)
        {
            View.Player.Move(direction);
        }

        private void Shoot()
        {
            Controller.Ammo.LaunchAmmo();
        }
        #endregion
    }
}