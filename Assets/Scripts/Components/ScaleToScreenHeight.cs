using UnityEngine;

public class ScaleToScreenHeight : AScaler
{
    protected override void Scale()
    {
        transform.localScale = new Vector3(
            transform.localScale.x,
            (worldScreenHeight / sr.sprite.bounds.size.y),
            1);
    }
}