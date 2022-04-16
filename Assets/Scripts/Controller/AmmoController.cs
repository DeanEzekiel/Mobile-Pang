using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MobilePang;
using MobilePang.View;

namespace MobilePang.Controller
{
    public class AmmoController : MVCHelper
    {
        #region Unity Callbacks
        private void Start()
        {
            // instantiate the balls
            Model.AmmoPool.PoolAmmos();
        }
        #endregion

        #region Implementation
        public void LaunchAmmo()
        {
            AmmoView ammo = Model.AmmoPool.GetFromPool();
            if(ammo != null)
            {
                ammo.gameObject.SetActive(true);
            }
        }
        #endregion
    }
}