using UnityEngine;

public class ScaleToScreen : AScaler
{
    protected override void Scale()
    {
        transform.localScale = new Vector3(
            worldScreenWidth / sr.sprite.bounds.size.x,
            worldScreenHeight / sr.sprite.bounds.size.y,
            1);
    }
}
