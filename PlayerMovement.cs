using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    public float DirX = 0f;
    private BoxCollider2D coll;
    private enum MovementState { idle, running, jumping, falling}
    [SerializeField]private float MoveSpeed = 5f;
    [SerializeField]private float JumpSpeed = 15f;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private LayerMask Launcher;
    SwordMovement swordThrowing;


    // Start is called before the first frame update
    private void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        DirX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(DirX * MoveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpSpeed);
        }
        UpdateAnimationState();
    }
    private void UpdateAnimationState()
    {
        MovementState state;
        if (DirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (DirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }


        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("PlayerState", (int)state);
    } 

    private bool IsGrounded()//checks if player object is touching the ground
    {
        if (
            Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, Ground) ||
            Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, Launcher)
            )
        {
            return true;
        }
        else return false;
    }
}
