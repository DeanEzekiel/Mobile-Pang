using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MobilePang;

namespace MobilePang.View
{
    public class GameView : MVCHelper
    {
        public TimeUIView Time;
        public PlayerView Player;

        public Transform AmmoPoolContainer;
        public Transform BallPoolContainer;
    }
}