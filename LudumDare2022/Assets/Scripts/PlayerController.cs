using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Editable Variables
    [SerializeField] public float speedConstant = 3;
    [SerializeField] public float jumpConstant = 3; 
    [SerializeField] public float size = 1;

    [SerializeField] public float sizeSpeedScalar = 1;
    [SerializeField] public float sizeJumpScalar = 1;
    [SerializeField] private KeyCode Jump;
    [SerializeField] private KeyCode UsePotion;

    //Components
    private Rigidbody2D playerBody;
    private BoxCollider2D playerCollider;
    [SerializeField] public PotionManager potManager;

    //Potion Variables
    private float sizeConstant;
    private float speedMultiplier = 1;
    private float jumpMultiplier = 1;

    //Other Variables
    private int jumpMax = 1;
    private int jumpCount = 0;
    public bool bIsJump = true;
    private float tileMultiplier = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();

        gameObject.transform.localScale = new Vector2(size, size);
        sizeConstant = size;
    }

    // Update is called once per frame
    void Update()
    {
        /************\
        |  Movement  |
        \************/

        //Left and Right Movement
        playerBody.velocity = new Vector2(speedConstant * speedMultiplier * tileMultiplier * Input.GetAxis("Horizontal"), playerBody.velocity.y);



        //Jump
        if (Input.GetKeyDown(Jump) && jumpCount < jumpMax)
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, tileMultiplier * jumpConstant * jumpMultiplier);
            jumpCount++;

        }

        //Use Potion
        if (Input.GetKeyDown(UsePotion))
        {
            potManager.ApplyNextEffect();
        }

    }

    public void SetSize(float scale)
    {
        gameObject.transform.localScale = new Vector2(scale,scale);
        size = scale/sizeConstant;
        bIsJump = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            jumpCount = 0;
            bIsJump = false;
        }

    }

    public bool GetJump()
    {
        return bIsJump;
    }

}
