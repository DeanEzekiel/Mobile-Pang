using System.Collections;
using System.Collections.Generic;
using MobilePang.Controller;
using MobilePang.Model;
using MobilePang.View;
using UnityEngine;

namespace MobilePang
{
    public class Main : ASingleton<Main>
    {
        public GameModel Model;
        public GameView View;
        public GameController Controller;
    }
}