using UnityEngine;

namespace MobilePang
{
    public abstract class AScaler : MonoBehaviour
    {
        protected SpriteRenderer sr;

        protected float worldScreenHeight;
        protected float worldScreenWidth;

        protected void Start()
        {
            sr = GetComponent<SpriteRenderer>();
            GetScreenDimensions();
            Scale();
        }

        private void GetScreenDimensions()
        {
            worldScreenHeight = Camera.main.orthographicSize * 2;
            worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        }

        protected abstract void Scale();
    }
}