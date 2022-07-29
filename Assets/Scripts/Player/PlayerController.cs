using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float collisionOffset = 0.05f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private ContactFilter2D movementFilter;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Vector2 movementInput;
    private List<RaycastHit2D> castCollision = new List<RaycastHit2D>();

    private void FixedUpdate()
    {
        // If movement input value is not 0, try to move.
        if (movementInput != Vector2.zero)
        {
            bool success = TryMove(movementInput);

            // Sliding on edges of collision.
            if (!success)
            {
                success = TryMove(new Vector2(movementInput.x, 0));
            }
            
            if (!success)
            {
                success = TryMove(new Vector2(0, movementInput.y));
            }
            
            animator.SetBool("isMoving", success);
        }

        else
        {
            animator.SetBool("isMoving", false);
        }
        
        FlipFace();
    }

    private bool TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            int count = rb.Cast(
                direction, // X and Y values between -1 and 1 that represent the direction from the body to look for collision.
                movementFilter, // The settings that determine where a collision can occur on such as layers to collide with.
                castCollision, // List of collisions to store the found collisions into after the Cast is finished.
                moveSpeed * Time.fixedDeltaTime +
                collisionOffset); // The amount to cast equal to movement plus an offset.

            if (count == 0)
            {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            }
            else
            {
                return false;
            }
        }

        else
        {
            // Can't move if there's no direction to move in.
            return false;
        }
    }

    private void FlipFace()
    {
        // Set direction of sprite to movement direciton.
        if (movementInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        
        else if (movementInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
    
    private void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }
}