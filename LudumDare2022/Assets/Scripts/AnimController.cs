using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    [SerializeField] float airAnimThreshold = .05f;

    private Animator anim;
    private Rigidbody2D body;
    private GameObject player;
    PlayerController playerController;

    private float size;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Disables based on potion state
        switch (GameController.instance.GameState)
        {
            case GameStates.PotionState:
                return;
            case GameStates.PlatformState:
                break;
        }
        anim.SetBool("Run", Input.GetAxis("Horizontal") != 0);

        size = playerController.size;

        if (Input.GetAxis("Horizontal") > 0.1)
        {
            transform.localScale = new Vector2(-1 * size, 1 * size);
            transform.localScale = new Vector2(-1 * size, -MathF.Sign(Physics2D.gravity.y) * size);
        }
        else if (Input.GetAxis("Horizontal") < -0.1)
        { 
            transform.localScale = new Vector2(1 * size, 1 * size);
            transform.localScale = new Vector2(1 * size, -MathF.Sign(Physics2D.gravity.y) * size);
        }

        float playerVelocity = player.GetComponent<Rigidbody2D>().velocity.y;

        SetJumpAnim(MathF.Abs(playerVelocity) > airAnimThreshold);
        anim.SetBool("IsVertical", playerVelocity * -MathF.Sign(Physics2D.gravity.y) < 0);
    }

    public void SetJumpAnim(bool bAnim)
    {
        anim.SetBool("Jump", bAnim);
    }

    public void SetDieAnim(bool bAnim)
    {
        anim.SetBool("IsDead", bAnim);
    }
}
