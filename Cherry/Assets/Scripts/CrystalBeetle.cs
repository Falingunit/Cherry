using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBeetle : MonoBehaviour
{

    private new Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private float speedBase = 1f;
    [SerializeField] private float speed = 0f;
    [SerializeField] private LayerMask layerMask;

    private int direction = 1;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
        if (Physics2D.BoxCast(transform.position, boxCollider.size, 0f, Vector2.right, 0.1f, layerMask))
        {
            direction = -1;
            spriteRenderer.flipX = true;
        }
        
        if (Physics2D.BoxCast(transform.position, boxCollider.size, 0f, Vector2.left, 0.1f, layerMask))
        {
            direction = 1;
            spriteRenderer.flipX = false;
        }

        speed = speedBase * direction;

        rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);

    }
}
