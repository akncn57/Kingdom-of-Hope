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

        if (movement != Vector2.zero)
        {
            // If player try move.
            FlipFace();
            Vector3 position = transform.position * playerSpeed;
            rb.MovePosition(rb.position + movement.normalized * playerSpeed * Time.fixedDeltaTime);
            animator.SetFloat("speed", movement.sqrMagnitude);
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