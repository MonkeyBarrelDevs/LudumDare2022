using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSDPotion : Potion
{
    public static event Action LSDPotionEvent;

    public override void ApplyEffect()
    {
        LSDPotionEvent?.Invoke();
    }

    public override void RemoveEffect()
    {
        LSDPotionEvent?.Invoke();
    }
}
