using System;
using System.Collections;
using KingdomOfHope.Movement;
using UnityEngine;
using Random = UnityEngine.Random;

namespace KingdomOfHope.Controller
{
    public class PlayerController : MonoBehaviour
    {
        #region Inspector Fields
        
        [SerializeField] private Rigidbody2D rigidbody;
        [SerializeField] private SpriteRenderer sprite;
        [SerializeField] private Transform attackDirection;
        [SerializeField] private float playerspeed;
        [SerializeField] private float attackRadius;
        [SerializeField] private Animator animator;
        [Header("----------AUDIO----------")]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip[] walkGrassSounds;
        [SerializeField] private AudioClip[] attackSounds;
        
        #endregion
        
        #region Private Fields
    
        private PcInputs inputs;
        private MoveWithMovePosition mover;
        private Attacker attacker;
        private FlipFace flipFace;
        private float horizontal;
        private float vertical;
        
        #endregion
        
        #region Unity Life Cycle

        private void Awake()
        {
            inputs = new PcInputs();
            mover = new MoveWithMovePosition(playerspeed, rigidbody);
            attacker = new Attacker(attackDirection, attackRadius);
            flipFace = new FlipFace(horizontal, sprite);
        }

        private void Update()
        {
            bool attackButton = inputs.AttackButtonDown;

            if (attackButton)
            {
                attacker.Attack();
                animator.SetTrigger("attack");
            }
        }

        private void FixedUpdate()
        {
            horizontal = inputs.Horizontal;
            vertical = inputs.Vertical;

            if (horizontal != 0 || vertical != 0)
            {
                flipFace.FlipingFace(horizontal, sprite);
                mover.Move(horizontal, vertical);
                animator.SetBool("isMoving", true);
            }
            else
                animator.SetBool("isMoving", false);
        }

        public void PlayRandomWalkSound()
        {
            AudioClip randomWalkSound = walkGrassSounds[Random.Range(0, walkGrassSounds.Length)];
            audioSource.clip = randomWalkSound;
            audioSource.Play();
        }

        public void PlayRandomAttackSound()
        {
            AudioClip randomAttackSound = attackSounds[Random.Range(0, attackSounds.Length)];
            audioSource.clip = randomAttackSound;
            audioSource.Play();
        }
        
        #endregion
    }
}