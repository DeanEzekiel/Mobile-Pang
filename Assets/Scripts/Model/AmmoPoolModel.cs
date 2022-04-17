using System.Collections;
using System.Collections.Generic;
using MobilePang.Controller;
using MobilePang.View;
using UnityEngine;
using MobilePang;

namespace MobilePang.Model
{
    public class AmmoPoolModel : MVCHelper
    {
        #region Fields
        private List<AmmoView> _pooledAmmos = new List<AmmoView>();

        [SerializeField]
        private AmmoView AmmoPrefab;
        #endregion

        #region Implementation
        public void PoolAmmos()
        {
            AmmoView tmp;
            for (int i = 0; i < Model.GetPoolSize(PoolableObject.Ammo); i++)
            {
                tmp = Instantiate(AmmoPrefab);
                tmp.transform.SetParent(View.AmmoPoolContainer);
                tmp.gameObject.SetActive(false);
                _pooledAmmos.Add(tmp);
            }
        }

        public AmmoView GetFromPool()
        {
            for (int i = 0; i < Model.GetPoolSize(PoolableObject.Ammo); i++)
            {
                if (!_pooledAmmos[i].gameObject.activeInHierarchy)
                {
                    return _pooledAmmos[i];
                }
            }
            return null;
        }

        public void ResetPool()
        {
            for (int i = 0; i < Model.GetPoolSize(PoolableObject.Ammo); i++)
            {
                if (_pooledAmmos[i].gameObject.activeInHierarchy)
                {
                    _pooledAmmos[i].gameObject.SetActive(false);
                }
            }
        }
        #endregion
    }
}