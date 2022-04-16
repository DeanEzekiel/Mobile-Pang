using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MobilePang;

namespace MobilePang.Model
{
    [CreateAssetMenu(fileName = "BallModel",
        menuName = "ScriptableObjects/New BallModel")]
    public class BallModel_SO : ScriptableObject
    {
        public BallType Type;
        public float Size;
        public int Points;
    }
}