using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private SpriteRenderer playerSprite;
    private BoxCollider2D coll;
    private float SwordDirection;
    [SerializeField]private float SwordVelocity = 30f; 
    GameObject player;


    private void Start()
    {
        player = GameObject.Find("Player");
        playerSprite = player.GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        if (playerSprite.flipX == true) SwordDirection = -1f;
        else if (playerSprite.flipX == false) SwordDirection = 1f;
    }

    private void Update()
    {
        if (SwordDirection < 0f) sprite.flipX = true;
        else if (SwordDirection > 0f) sprite.flipX = false;
        rb.velocity = new Vector2(SwordDirection*SwordVelocity, 0f);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
