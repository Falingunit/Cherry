using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public CharacterController2D controller;

    [SerializeField] float speed = 7f;

    private float dirX = 0f;
    private bool isJumping = false;

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal") * speed;
        
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {

        controller.Move(dirX * Time.fixedDeltaTime, false, isJumping);
        isJumping = false;

    }
}
