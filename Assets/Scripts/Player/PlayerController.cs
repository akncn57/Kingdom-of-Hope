using System;
using System.Collections;
using System.Collections.Generic;
using KingdomOfHope.Inputs;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Animator animator;
    [SerializeField] private float playerSpeed;
    
    private IPlayerInput input;
    private float horizontal;
    private float vertical;
    private Vector2 movement;

    private void Awake()
    {
        input = new PcInputs();
    }

    private void FixedUpdate()
    {
        horizontal = input.Horizontal;
        vertical = input.Vertical;
        movement.x = horizontal;
        movement.y = vertical;

        Vector3 position = transform.position * playerSpeed;
        rigidbody.MovePosition(rigidbody.position + movement * playerSpeed * Time.fixedDeltaTime);
        
        animator.SetFloat("Move", horizontal + vertical);
    }
}
