using UnityEngine;

public class ScaleToScreenWidth : AScaler
{
    protected override void Scale()
    {
        transform.localScale = new Vector3(
            (worldScreenWidth / sr.sprite.bounds.size.x),
            transform.localScale.y,
            1);
    }
}