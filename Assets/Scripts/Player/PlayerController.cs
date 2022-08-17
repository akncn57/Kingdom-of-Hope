using System;
using KingdomOfHope.Movement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float playerspeed;
    [SerializeField] private Animator animator;
    
    private PcInputs inputs;
    private MoveWithMovePosition mover;

    private void Awake()
    {
        inputs = new PcInputs();
        mover = new MoveWithMovePosition(playerspeed, rigidbody);
    }

    private void FixedUpdate()
    {
        float horizontal = inputs.Horizontal;
        float vertical = inputs.Vertical;

        if (horizontal != 0 || vertical != 0)
        {
            mover.Move(horizontal, vertical);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
}