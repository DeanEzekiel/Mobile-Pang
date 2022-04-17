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
            if (Controller.Time.IsTimeTicking() && Model.Player.IsPlaying)
            {
                View.Player.Move(direction);
            }
        }

        private void Shoot()
        {
            if (Controller.Time.IsTimeTicking() && Model.Player.IsPlaying)
            {
                Controller.Ammo.LaunchAmmo();
            }
        }

        public void StartPlaying()
        {
            Model.Player.IsPlaying = true;
        }
        public void HaltPlaying()
        {
            Model.Player.IsPlaying = false;
        }
        #endregion
    }
}