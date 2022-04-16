using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MobilePang;

namespace MobilePang.Model
{
    [CreateAssetMenu(fileName = "PoolModel",
        menuName = "ScriptableObjects/New PoolModel")]
    public class PoolModelSO : ScriptableObject
    {
        public int Ammos = 10;
        public int Balls = 20;
    }
}