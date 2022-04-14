using System.Collections;
using System.Collections.Generic;
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