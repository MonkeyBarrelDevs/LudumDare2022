using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPotion : Potion
{
    [SerializeField] private float jumpPower = 3;

    private float tileMultiplier = 3;
    private Rigidbody2D playerBody;
    private PlayerController playerController;

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }
    public override void ApplyEffect()
    {
        playerBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        playerBody.velocity = new Vector2(playerBody.velocity.x, tileMultiplier * jumpPower * -Mathf.Sign(Physics2D.gravity.y));
    }

    public override void RemoveEffect()
    {
        //Empty body is fine, do nothing
    }
}
