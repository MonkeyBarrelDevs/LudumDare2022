using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D body;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Run", Input.GetAxis("Horizontal") != 0);

        if (Input.GetAxis("Horizontal") > 0.1)
            transform.localScale = new Vector2(-1, transform.localScale.y);
        else if (Input.GetAxis("Horizontal") < -0.1)
            transform.localScale = new Vector2(1, transform.localScale.y);

        transform.localScale = new Vector2(transform.localScale.x, -MathF.Sign(Physics2D.gravity.y));
       
        anim.SetBool("IsVertical", player.GetComponent<Rigidbody2D>().velocity.y * transform.localScale.y < 0);

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
