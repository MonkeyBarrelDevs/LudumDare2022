using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Potion : MonoBehaviour
{
    public Sprite ItemSprite;
    public abstract void ApplyEffect();
    public abstract void RemoveEffect();
}
