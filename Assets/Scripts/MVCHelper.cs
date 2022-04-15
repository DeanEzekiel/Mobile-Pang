using System.Collections;
using System.Collections.Generic;
using MobilePang.Controller;
using MobilePang.Model;
using MobilePang.View;
using UnityEngine;

namespace MobilePang
{
    public class MVCHelper : MonoBehaviour
    {
        protected GameModel Model => Main.Instance.Model;
        protected GameView View => Main.Instance.View;
        protected GameController Controller => Main.Instance.Controller;
    }
}