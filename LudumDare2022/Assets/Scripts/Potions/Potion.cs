using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Potion : MonoBehaviour
{
    [SerializeField] protected Sprite itemSprite;
    public abstract void ApplyEffect();
    public abstract void RemoveEffect();
}
