using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerModel",
    menuName = "ScriptableObjects/New PlayerModel")]
public class PlayerModel : ScriptableObject
{
    public int Life = 3;
    public float Speed = 6;
    public float ShootCooldown = 0.5f;
    public bool IsProtected = false;
}