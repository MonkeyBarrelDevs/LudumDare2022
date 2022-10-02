using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Run", Input.GetAxis("Horizontal") != 0);

        if (Input.GetAxis("Horizontal") > 0.1)
            transform.localScale = new Vector2(-1, 1);
        else if (Input.GetAxis("Horizontal") < -0.1)
            transform.localScale = new Vector2(1, 1);
    }
}
