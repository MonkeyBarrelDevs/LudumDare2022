using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Editable Variables
    [SerializeField] private int speed;

    //Components
    private Rigidbody2D playerBody;
    private BoxCollider2D playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        
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

        
        
    }

}
