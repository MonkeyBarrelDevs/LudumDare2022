using System.Collections;
using System.Collections.Generic;
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
            transform.localScale = new Vector2(-1, 1);
        else if (Input.GetAxis("Horizontal") < -0.1)
            transform.localScale = new Vector2(1, 1);

        anim.SetBool("Jump",player.GetComponent<PlayerController>().GetJump());
        anim.SetBool("IsVertical", player.GetComponent<Rigidbody2D>().velocity.y > 0);


    }

    public void Die()
    {
        anim.SetBool("IsDead", true);
    }
}
