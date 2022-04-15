using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobilePang
{
    public class PlayerController : MVCHelper
    {

        #region Unity Callbacks
        private void FixedUpdate()
        {
            MovementControl();
        }

        #endregion

        #region Implementation
        private void MovementControl()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                View.Player.Move(Vector3.left);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                View.Player.Move(Vector3.right);
            }

            
        }
        #endregion
    }
}