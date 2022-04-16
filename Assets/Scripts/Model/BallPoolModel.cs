﻿using System.Collections;
using System.Collections.Generic;
using MobilePang.Controller;
using MobilePang.View;
using UnityEngine;
using MobilePang;

namespace MobilePang.Model
{
    public class BallPoolModel : MVCHelper
    {
        #region Fields
        private List<BallView> _pooledBalls = new List<BallView>();

        [SerializeField]
        private BallView BallPrefab;

        public float XRandomMin = -2f;
        public float XRandomMax = 2f;
        public float YRandomMin = 1f;
        public float YRandomMax = 2f;

        public float FloorXRandomMin = -1f;
        public float FloorXRandomMax = 1f;
        public float FloorYRandom = 1f;
        #endregion

        #region Implementation
        public void PoolBalls()
        {
            BallView tmp;
            for (int i = 0; i < Model.GetPoolSize(PoolableObject.Ball); i++)
            {
                tmp = Instantiate(BallPrefab);
                tmp.transform.SetParent(View.BallPoolContainer);
                tmp.gameObject.SetActive(false);
                _pooledBalls.Add(tmp);
            }
        }

        public BallView GetFromPool()
        {
            for (int i = 0; i < Model.GetPoolSize(PoolableObject.Ball); i++)
            {
                if (!_pooledBalls[i].gameObject.activeInHierarchy)
                {
                    return _pooledBalls[i];
                }
            }
            return null;
        }
        #endregion
    }
}