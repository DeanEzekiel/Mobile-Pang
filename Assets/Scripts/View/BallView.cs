using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MobilePang;
using MobilePang.Model;

namespace MobilePang.View
{
    public class BallView : MVCHelper
    {
        [SerializeField]
        private BallType _type;
        private float _size = 1f;
        private int _points = 0;

        Rigidbody2D _rb;

        #region Unity Callbacks
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            SetBall();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(Tag.AMMO))
            {
                CheckMultiplier();
                Controller.AddPoints(_points);

                // pull 2 balls and activate
                if ((_type != BallType.XSmall) || (_type != BallType.None))
                {
                    DivideBall();
                }

                // deactivate this ball
                gameObject.SetActive(false);
            }
            else if (collision.gameObject.CompareTag(Tag.FLOOR))
            {
                var xMin = Model.BallPool.FloorXRandomMin;
                var xMax = Model.BallPool.FloorXRandomMax;
                var y = Model.BallPool.FloorYRandom;

                if (_rb.velocity.y < Model.BallSlowFactor)
                {
                    _rb.AddForce(new Vector2(Random.Range(xMin, xMax), y),
                        ForceMode2D.Impulse);
                }
            }
        }
        #endregion

        #region Implementation
        public void SetBallType(BallType ballType)
        {
            _type = ballType;
        }

        [ContextMenu("Reset Ball's Size")]
        private void SetBall()
        {
            if (_type == BallType.None)
            {
                _type = BallType.Large;
            }

            SetBallSpecs(Model.GetBallTemplate(_type));
            transform.localScale = new Vector3(_size, _size, 1);
        }

        public void SetBallSpecs(BallModel_SO template)
        {
            _type = template.Type;
            _size = template.Size;
            _points = template.Points;
        }

        private void DivideBall()
        {
            BallType newBallType = Model.GetNextBallType(_type);

            if (newBallType != BallType.None)
            {
                ActivateBall(newBallType, Direction.Left);
                ActivateBall(newBallType, Direction.Right);
            }
        }

        private void ActivateBall(BallType newBallType, Direction direction)
        {
            float xPos = _size / 2;
            var xMin = Model.BallPool.XRandomMin;
            var xMax = Model.BallPool.XRandomMax;
            var yMin = Model.BallPool.YRandomMin;
            var yMax = Model.BallPool.YRandomMax;

            if(direction == Direction.Left)
            {
                xPos *= -1;
            }

            BallView newBall = Controller.Ball.GetBallFromPool();
            newBall.SetBallType(newBallType);
            //newBall.SetBallSpecs(Model.GetBallTemplate(newBallType));
            newBall.transform.position = new Vector3(
                transform.position.x + xPos,
                transform.position.y,
                transform.position.z
                );
            newBall.gameObject.SetActive(true);

            newBall._rb.AddForce(
                new Vector2(
                Random.Range(xMin, xMax), Random.Range(yMin, yMax)
                ),
                ForceMode2D.Impulse);
        }

        private void CheckMultiplier()
        {
            if (Model.LastHitTime == 0)
            {
                Model.AddMultiplier();
            }
            else if ((Time.time - Model.LastHitTime) < GameModel.StreakSec)
            {
                Model.AddMultiplier();
            }
            else if ((Time.time - Model.LastHitTime) > GameModel.StreakSec)
            {
                Model.ResetMultiplier();
            }
            // register the time
            Model.LastHitTime = Time.time;
        }
        #endregion
    }
}