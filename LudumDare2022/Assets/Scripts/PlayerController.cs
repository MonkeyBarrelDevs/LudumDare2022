using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Editable Variables
    [SerializeField] public float speedConstant = 1f;
    [SerializeField] public float jumpConstant = 1; 
    [SerializeField] public float size = 1;

    [SerializeField] public float sizeSpeedScalar = 1;
    [SerializeField] public float sizeJumpScalar = 1;
    [SerializeField] private KeyCode Jump;
    [SerializeField] private KeyCode UsePotion;


    //Components
    private Rigidbody2D playerBody;
    private CapsuleCollider2D playerCollider;
    [SerializeField] public PotionManager potManager;
    private GameObject player;


    //Potion Variables
    private float sizeConstant;
    private float speedMultiplier = 1;


    //Other Variables
    private bool isGrounded;
    private int jumpMax = 1;
    private int jumpCount = 0;
    public bool bIsJump = true;
    private float tileMultiplier = 2;


    // Start is called before the first frame update

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();

        gameObject.transform.localScale = new Vector3(size, size, size);
        sizeConstant = size;

        player = GameObject.FindGameObjectWithTag("Player");


    }

    // Update is called once per frame
    void Update()
    {
        /************\
        |  Movement  |
        \************/
        //Disables based on potion state
        switch (GameController.instance.GameState)
        {
            case GameStates.PotionState:
                return;
            case GameStates.PlatformState:
                break;
        }




        //Left and Right Movement
        playerBody.velocity = new Vector2(speedConstant * sizeSpeedScalar * speedMultiplier * tileMultiplier * Input.GetAxis("Horizontal"), playerBody.velocity.y);
        if (isGrounded)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0)
            {
                if(!AudioManager.instance.isPlaying("Run"))
                    AudioManager.instance.Play("Run");
            }
            else
                AudioManager.instance.Stop("Run");
        }
        else
            AudioManager.instance.Stop("Run");


            //Jump
        if (Input.GetKeyDown(Jump) && jumpCount < jumpMax)
        {
            isGrounded = false;
            playerBody.velocity = new Vector2(playerBody.velocity.x, tileMultiplier * jumpConstant * -MathF.Sign(Physics2D.gravity.y));
            jumpCount++;
            player.GetComponent<AnimController>().SetJumpAnim(true);
            AudioManager.instance.Play("Jump");
        }

        //Use Potion
        if (Input.GetKeyDown(UsePotion))
        {
            PotionManager.instance.ApplyNextEffect();
        }

        
    }

    public void SetSize(float scale)
    {
        transform.localScale = new Vector3(scale,scale/2,scale);
        Debug.Log(transform.localScale);
        sizeSpeedScalar = scale;
        sizeJumpScalar = scale; 
    }
    public void MultiplySpeedMultiplier(float scale)
    {
        speedMultiplier = speedMultiplier * scale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            if(jumpCount > 0)
                AudioManager.instance.Play("Land");
            jumpCount = 0;
            player.GetComponent<AnimController>().SetJumpAnim(false);
        }
    }



}
