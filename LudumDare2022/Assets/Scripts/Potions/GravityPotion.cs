using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPotion : Potion
{
    public override void ApplyEffect()
    {
        GravFlip();
    }

    public override void RemoveEffect()
    {
        GravFlip();
    }

    private void GravFlip()
    {
        Physics2D.gravity = -Physics2D.gravity;
        //make character sprite flip n things
    }
}
