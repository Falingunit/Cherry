using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed = 7, jumpVel = 5;

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
        //Horizontal Movement
        dirX = Input.GetAxisRaw("Horizontal");

        rigidbody.velocity = new Vector2(dirX * speed, rigidbody.velocity.y); ;

        //Jumping
        if (Input.GetButtonDown("Jump") && isLanded)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpVel);
        }

    }

}
