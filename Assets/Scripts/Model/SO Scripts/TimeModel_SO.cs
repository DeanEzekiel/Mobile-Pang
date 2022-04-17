using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MobilePang;

namespace MobilePang.Model
{
    [CreateAssetMenu(fileName = "TimeModel",
        menuName = "ScriptableObjects/New TimeModel")]
    public class TimeModel_SO : ScriptableObject
    {
        [Range(0f, 200f)]
        [Tooltip("The number of seconds per round.")]
        public float TimeRemaining = 100f;
        public bool IsTimeTicking = false;
    }
}