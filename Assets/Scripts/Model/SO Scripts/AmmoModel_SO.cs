using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MobilePang;

namespace MobilePang.Model
{
    [CreateAssetMenu(fileName = "AmmoModel",
        menuName = "ScriptableObjects/New AmmoModel")]
    public class AmmoModel_SO : ScriptableObject
    {
        public float Lifetime = 1;
        public float Speed = 20f;
    }
}