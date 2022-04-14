using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobilePang
{
    public class GameView : MonoBehaviour
    {
        public void DisplaySomeString(string someString)
        {
            print($"Current value: {someString}");
        }
    }
}