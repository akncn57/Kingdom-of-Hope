using System;
using KingdomOfHope.Combats;
using UnityEngine;
using KingdomOfHope.Inputs;
using KingdomOfHope.Combats;

public class PlayerController : MonoBehaviour
{
    #region Unity Inspector

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private float playerSpeed;

    #endregion

    #region Private Fields

    private IPlayerInput input;
    private float horizontal;
    private float vertical;
    private Vector2 movement;
    //private bool canMove = true;

    #endregion

    #region Unity LifeCycle

    private void Awake()
    {
        // Create new PC input.
        input = new PcInputs();
    }

    private void Update()
    {
        Attack();
        Debug.Log("Horizontal :" + horizontal);
    }

    private void FixedUpdate()
    {
        Move();
    }

    #endregion

    #region Private Methods

    private void Move()
    {
        // Get horizontal and vertical move value.
        horizontal = input.Horizontal;
        vertical = input.Vertical;
        movement.x = horizontal;
        movement.y = vertical;

        bool success = movement != Vector2.zero;

        if (success)
        {
            // If player try move.
            FlipFace();
            rb.MovePosition(rb.position + movement.normalized * playerSpeed * Time.fixedDeltaTime);
            animator.SetBool("isMoving", success);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void Attack()
    {
        if (input.AttackButtonDown)
        {
            animator.SetTrigger("attack");
        }
    }

    private void FlipFace()
    {
        if (movement.x < 0)
        {
            playerSprite.flipX = true;
        }
        else if (movement.x > 0)
        {
            playerSprite.flipX = false;
        }
    }

    #endregion
}