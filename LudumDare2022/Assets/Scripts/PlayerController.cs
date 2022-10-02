using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Editable Variables
    [SerializeField] public float speed = 3;
    private float initialSpeed;
    [SerializeField] public float jumpPower = 3;
    private float initialJumpPower;
    [SerializeField] public float baseSize = 1;
    private float initialSize;
    [SerializeField] public float sizeSpeedScalar = 1;
    [SerializeField] public float sizeJumpScalar = 1;
    [SerializeField] private KeyCode Jump;
    [SerializeField] private KeyCode UsePotion;

    //Components
    private Rigidbody2D playerBody;
    private BoxCollider2D playerCollider;
    [SerializeField] public PotionManager potManager;

    //Other Variables
    private int jumpMax = 1;
    private int jumpCount = 0;
    private float tileMultiplier = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
        initialJumpPower = jumpPower;
        initialSize = baseSize;
        SetSize(baseSize);
    }

    // Update is called once per frame
    void Update()
    {
        /************\
        |  Movement  |
        \************/

        //Left and Right Movement
        playerBody.velocity = new Vector2(speed * tileMultiplier * Input.GetAxis("Horizontal"), playerBody.velocity.y);



        //Jump
        if (Input.GetKeyDown(Jump) && jumpCount < jumpMax)
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, tileMultiplier * jumpPower);
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
        speed = initialSpeed * (scale / initialSize) * sizeSpeedScalar;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            jumpCount = 0;
        }

    }

}
