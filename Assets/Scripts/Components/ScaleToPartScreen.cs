using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobilePang
{
    public class ScaleToPartScreen : AScaler
    {
        [SerializeField]
        private float divideWidth;
        [SerializeField]
        private float divideHeight;

        protected override void Scale()
        {
            transform.localScale = new Vector3(
                (worldScreenWidth / sr.sprite.bounds.size.x / divideWidth),
                (worldScreenHeight / sr.sprite.bounds.size.y / divideHeight),
                1);
        }
    }
}