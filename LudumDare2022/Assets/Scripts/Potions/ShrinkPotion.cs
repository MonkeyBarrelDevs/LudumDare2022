using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkPotion : Potion
{
    private GameObject playerObj;
    private void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
    }
    public override void ApplyEffect()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerObj.GetComponent<PlayerController>().SetSize(.5f);
    }

    public override void RemoveEffect()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerObj.GetComponent<PlayerController>().SetSize(1f);
    }
}
