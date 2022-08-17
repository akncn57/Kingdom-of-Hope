using KingdomOfHope.Movement;
using UnityEngine;

namespace KingdomOfHope.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidbody;
        [SerializeField] private SpriteRenderer sprite;
        [SerializeField] private float playerspeed;
        [SerializeField] private Animator animator;
    
        private PcInputs inputs;
        private MoveWithMovePosition mover;
        private FlipFace flipFace;

        private void Awake()
        {
            inputs = new PcInputs();
            mover = new MoveWithMovePosition(playerspeed, rigidbody);
            flipFace = new FlipFace();
        }

        private void FixedUpdate()
        {
            float horizontal = inputs.Horizontal;
            float vertical = inputs.Vertical;

            if (horizontal != 0 || vertical != 0)
            {
                flipFace.FlipingFace(horizontal, sprite);
                mover.Move(horizontal, vertical);
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }
}