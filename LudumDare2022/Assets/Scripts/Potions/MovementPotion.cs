using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPotion : Potion
{
    [Range(1, 2)]
    [SerializeField] float speedMultiplier = 2;
    private PlayerController playerController;
    void Start()
    {
        playerController =  GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    public override void ApplyEffect()
    {
        playerController.MultiplySpeed(speedMultiplier);
    }

    public override void RemoveEffect()
    {
        playerController.MultiplySpeed(1/speedMultiplier);
    }
}
