using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MobilePang;
using TMPro;

namespace MobilePang.View
{
    public class TimeUIView : MVCHelper
    {
        [SerializeField]
        private TextMeshProUGUI _timer;

        private void Update()
        {
            _timer.text = Model.Time.Timer.TimeRemaining.ToString("F0");
        }
    }
}