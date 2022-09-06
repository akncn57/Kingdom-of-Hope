using System;
using System.Collections;
using Animation;
using KingdomOfHope.Combats;
using KingdomOfHope.Inputs;
using KingdomOfHope.Movement;
using UnityEngine;
using Random = UnityEngine.Random;

namespace KingdomOfHope.Controller
{
    public class PlayerController : MonoBehaviour, IEntityController
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
    
        private IPlayerInput inputs;
        private IAnimation animations;
        private IMover mover;
        private IAttacker attacker;
        private IFlipFace flipFace;
        
        private float horizontal;
        private float vertical;
        private bool isMoving = false;
        
        #endregion
        
        #region Unity Life Cycle

        private void Awake()
        {
            inputs = new PcInputs();
            animations = new CharacterAnimations(animator);
            mover = new MoveWithMovePosition(playerspeed, rigidbody);
            attacker = new Attacker(attackDirection, attackRadius);
            flipFace = new FlipFaceWithSpriteRenderer(horizontal, sprite);
        }

        private void Update()
        {
            bool attackButton = inputs.AttackButtonDown;

            if (attackButton)
            {
                attacker.Attack();
                animations.AttackAnimation();
            }
        }

        private void FixedUpdate()
        {
            horizontal = inputs.Horizontal;
            vertical = inputs.Vertical;

            if (horizontal != 0 || vertical != 0)
            {
                isMoving = true;
                flipFace.FlipingFace(horizontal);
                mover.Move(horizontal, vertical);
                animations.MoveAnimation(isMoving);
            }
            else
            {
                isMoving = false;
                animations.MoveAnimation(isMoving);
            }
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