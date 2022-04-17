using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MobilePang;

namespace MobilePang.Model
{
    [CreateAssetMenu(fileName = "PlayerModel",
        menuName = "ScriptableObjects/New PlayerModel")]
    public class PlayerModel_SO : ScriptableObject
    {
        public int Life = 3;
        public int _score = 0;
        public int _multiplier = 0;

        public float Speed = 6;
        public float ShootCooldown = 0.5f;
        public bool IsProtected = false;
    }
}