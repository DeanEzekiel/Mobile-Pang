using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobilePang
{
    public class GameController : MonoBehaviour
    {
        private void Start()
        {
            Main.Helper.View.DisplaySomeString(Main.Helper.Model.SomeString);

            Main.Helper.Model.SomeString = "modified string";
            Main.Helper.View.DisplaySomeString(Main.Helper.Model.SomeString);
        }
    }
}