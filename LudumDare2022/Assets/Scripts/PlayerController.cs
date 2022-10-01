using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Editable Variables
    [SerializeField] private float speed = 3;
    [SerializeField] private float jumpPower = 3;
    [SerializeField] private KeyCode Jump;
    [SerializeField] private KeyCode UsePotion;

    //Components
    private Rigidbody2D playerBody;
    private BoxCollider2D playerCollider;

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
        if (Input.GetKeyDown(Jump))
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, jumpPower);
        }

        //Use Potion
        if (Input.GetKeyDown(UsePotion))
        {

        }

    }

}
