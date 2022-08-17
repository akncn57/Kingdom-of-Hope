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
        private Attacker attacker;
        private FlipFace flipFace;

        private void Awake()
        {
            inputs = new PcInputs();
            mover = new MoveWithMovePosition(playerspeed, rigidbody);
            attacker = new Attacker();
            flipFace = new FlipFace();
        }

        private void FixedUpdate()
        {
            float horizontal = inputs.Horizontal;
            float vertical = inputs.Vertical;
            bool attackButton = inputs.AttackButtonDown;

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
            
            if (attackButton)
                attacker.Attack();
        }
    }
}