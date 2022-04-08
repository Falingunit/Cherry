using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(0, 50)] public float speed = 7;
    [Range(0, 50)] public float jumpVel = 5;

    public float fallMultiplier = 2.5f;
    public float slowJumpMultiplier = 2f;

    public float wallJumpHorizontal, wallJumpVertical;

    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;

    private float dirX;

    private bool isLanded = false;


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        PlayerMovement();
        PlayerJumping();
        PlayerGrabbing();
        AnimationController();

        if (Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, LayerMask.GetMask("Ground")))
        {
            isLanded = true;
        }
        else 
        { 
            isLanded = false;
        }

    }

    private void AnimationController()
    {
        if (dirX > .1f)
        {
            spriteRenderer.flipX = false;
        }else if (dirX < -.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void PlayerMovement()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        rigidbody.velocity = new Vector2(dirX * speed, rigidbody.velocity.y);

    }

    private void PlayerJumping()
    {

        if (Input.GetButtonDown("Jump") && isLanded)
        {
            rigidbody.velocity = Vector2.up * jumpVel;
        }

        if (rigidbody.velocity.y < 0)
        {
            rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }else if (rigidbody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (slowJumpMultiplier - 1) * Time.deltaTime;
        }

    }

    private void PlayerGrabbing()
    {

    }

}
