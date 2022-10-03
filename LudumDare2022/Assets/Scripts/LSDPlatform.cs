using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;
using UnityEngine.VFX;

[RequireComponent(typeof(Collider2D))]

public class LSDPlatform : MonoBehaviour
{
    [SerializeField] bool startsActive = true;
    [SerializeField] Color activeColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    [SerializeField] Color inactiveColor = new Color(1.0f, 1.0f, 1.0f, .25f);
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
        platformCollider.enabled = startsActive;
        tilemap.color = (startsActive) ? activeColor : inactiveColor;

        LSDPotion.LSDPotionEvent += TogglePlatform;
    }

    private void OnDestroy()
    {
        LSDPotion.LSDPotionEvent -= TogglePlatform;
    }

    void TogglePlatform()
    {
        platformCollider.enabled = !platformCollider.enabled;
        tilemap.color = (platformCollider.enabled) ? activeColor : inactiveColor;
    }
}
