using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class LSDPlatform : MonoBehaviour
{
    Collider2D platformCollider;
    private void Awake()
    {
        platformCollider = GetComponent<Collider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        LSDPotion.LSDPotionEvent += TogglePlatform;
    }

    void TogglePlatform()
    {
        platformCollider.enabled = !platformCollider.enabled;
    }
}
