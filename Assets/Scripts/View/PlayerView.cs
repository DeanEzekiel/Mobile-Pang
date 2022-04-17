using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MobilePang;

namespace MobilePang.View
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerView : MVCHelper
    {
        Rigidbody2D m_Rigidbody;

        public Transform SpawnPoint;

        #region Unity Callbacks
        private void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody2D>();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(Tag.BALL))
            {
                Controller.DeductLife();
                if (Model.Player.Life == 0)
                {
                    Controller.UI.OnGameOver();
                }
                else
                {
                    Controller.UI.OnLevelFailed();
                }
            }
        }
        #endregion

        #region Implementation
        public void Move(Direction direction)
        {
            Vector3 movementDirection = Vector3.zero;

            if(direction == Direction.Left)
            {
                movementDirection = Vector3.left;
            }
            else if(direction == Direction.Right)
            {
                movementDirection = Vector3.right;
            }

            m_Rigidbody.MovePosition(transform.position + movementDirection *
                Time.deltaTime * Model.Player.Speed);
        }
        #endregion
    }
}