using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MobilePang;
using TMPro;

namespace MobilePang.View
{
    public class UIView : MVCHelper
    {
        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        public void WaitThenStartGame()
        {
            StopAllCoroutines();
            StartCoroutine(StartCountdown());
        }

        private IEnumerator StartCountdown()
        {
            yield return new WaitForSeconds(Model.UI.WaitTime);
            Deactivate();
            Controller.UI.ActualStartGame();
        }

        public void WaitThenRestartLevel()
        {
            StopAllCoroutines();
            StartCoroutine(RestartCountdown());
        }

        private IEnumerator RestartCountdown()
        {
            yield return new WaitForSeconds(Model.UI.WaitTime);
            Deactivate();

            Controller.UI.OnRestartCurrentLevel();
        }
    }
}