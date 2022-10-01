using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Editable Variables
    [SerializeField] private float speed = 3;
    [SerializeField] private float jumpPower = 3;
    [SerializeField] private float baseSize = 1;
    [SerializeField] private KeyCode Jump;
    [SerializeField] private KeyCode UsePotion;

    //Components
    private Rigidbody2D playerBody;
    private BoxCollider2D playerCollider;
    //[SerializeField] static Potion

    //Other Variables
    private int jumpMax = 1;
    private int jumpCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        float tileMultiplier = 3;
        speed = tileMultiplier * speed;
        jumpPower = tileMultiplier * jumpPower;
    }

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        SetSize(baseSize);
    }

    // Update is called once per frame
    void Update()
    {
        /************\
        |  Movement  |
        \************/

        //Left and Right Movement
        playerBody.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), playerBody.velocity.y);



        //Jump
        if (Input.GetKeyDown(Jump) && jumpCount < jumpMax)
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, jumpPower);
            jumpCount++;
        }

        //Use Potion
        if (Input.GetKeyDown(UsePotion))
        {

        }

    }

    private void SetSize(float scale)
    {
        gameObject.transform.localScale = new Vector2(scale,scale);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            jumpCount = 0;
        }

    }

}
