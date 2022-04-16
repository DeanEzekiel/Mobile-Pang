using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MobilePang;
using MobilePang.View;

namespace MobilePang.Controller
{
    public class BallController : MVCHelper
    {
        #region Unity Callbacks
        private void Start()
        {
            // instantiate the balls
            Model.BallPool.PoolBalls();
        }
        #endregion

        #region Implementation
        public BallView GetBallFromPool()
        {
            return Model.BallPool.GetFromPool();
        }
        #endregion
    }
}