using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class LSDPlatform : MonoBehaviour
{
    Collider2D platformCollider;
    Tilemap tilemap;
   
    private void Awake()
    {
        platformCollider = GetComponent<Collider2D>();
        tilemap = GetComponent<Tilemap>();
    }
    // Start is called before the first frame update
    void Start()
    {
        LSDPotion.LSDPotionEvent += TogglePlatform;
        platformCollider.enabled = !platformCollider.enabled;
        tilemap.color = new Color(1.0f, 1.0f, 1.0f, .25f);
    
    }
    


    void TogglePlatform()
    {
        platformCollider.enabled = !platformCollider.enabled;

        if (platformCollider.enabled == true)
        {
            tilemap.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else
        {
            tilemap.color = new Color(1.0f, 1.0f, 1.0f, .25f);
        }
    }
}
