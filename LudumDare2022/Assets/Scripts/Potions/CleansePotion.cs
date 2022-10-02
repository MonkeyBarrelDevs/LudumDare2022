using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleansePotion : Potion
{
    public override void ApplyEffect()
    {
        PotionManager.instance.RemoveAllEffects();
    }

    public override void RemoveEffect()
    {
        //what are you even going to cleanse lol? you just removed all the effects? 
    }
}
