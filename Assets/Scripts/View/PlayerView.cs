using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobilePang
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerView : MVCHelper
    {
        Rigidbody2D m_Rigidbody;

        #region Unity Callbacks
        private void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody2D>();
        }
        #endregion

        #region Implementation
        public void Move(Vector3 movementDirection)
        {
            //transform.Translate(
            //    (movementDirection * Model.Player.Speed * Time.deltaTime),
            //    Space.World);
            m_Rigidbody.MovePosition(transform.position + movementDirection *
                Time.deltaTime * Model.Player.Speed);
        }
        #endregion
    }
}