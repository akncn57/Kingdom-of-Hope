using System;
using System.Collections;
using System.Collections.Generic;
using Animation;
using KingdomOfHope.Combats;
using KingdomOfHope.Enemy.States;
using UnityEngine;
using KingdomOfHope.Movement;
using KingdomOfHope.StateMachines;

namespace KingdomOfHope.Controller
{
    public class EnemyController : MonoBehaviour, IEntityController
    {
        [SerializeField] private Rigidbody2D rigidbody;
        [SerializeField] private SpriteRenderer sprite;
        [SerializeField] private Animator animator;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float chaseDistance;
        [SerializeField] private float attackDistance;
        [SerializeField] private Transform[] patrols;

        private IMover mover;
        private IAttacker attacker;
        private IAnimation animation;
        private IFlipFace flipFaceWithTransform;
        private IEntityController player;
        private StateMachine stateMachine;
        
        private void Awake()
        {
            mover = new MoveWithTranslate(moveSpeed, transform);
            // attacker = new Attacker(attackDirection, attackRadius);
            flipFaceWithTransform = new FlipWithTransform(this.transform);
            animation = new CharacterAnimations(animator);
            stateMachine = new StateMachine();
            player = FindObjectOfType<PlayerController>();
        }

        private void Start()
        {
            Idle idle = new Idle(this, mover, animation, flipFaceWithTransform);
            Walk walk = new Walk(this, mover, flipFaceWithTransform, animation, patrols);
            ChasePlayer chasePlayer = new ChasePlayer(this, player, mover, flipFaceWithTransform, animation);
            Dead dead = new Dead();
            TakeHit takeHit = new TakeHit();
            Attack attack = new Attack(animation);
            
            stateMachine.AddTransition(idle, walk, () => !idle.IsIdle);
            stateMachine.AddTransition(idle, chasePlayer, () => FindDistanceFromPlayer() < chaseDistance);
            stateMachine.AddTransition(walk, chasePlayer, () => FindDistanceFromPlayer() < chaseDistance);
            stateMachine.AddTransition(chasePlayer, attack, () => FindDistanceFromPlayer() < attackDistance);
            stateMachine.AddTransition(walk, idle, () => !walk.IsWalking);
            stateMachine.AddTransition(chasePlayer, idle, () => FindDistanceFromPlayer() > chaseDistance);
            stateMachine.AddTransition(attack, chasePlayer, () => FindDistanceFromPlayer() > attackDistance);
            //stateMachine.AddAnyState(dead, () => XXX);
            //stateMachine.AddAnyState(takeHit, () => XXX);
            //stateMachine.AddTransition(takeHit, chasePlayer, () => XXX);
            stateMachine.SetState(idle);
        }

        private void Update()
        {
            stateMachine.Tick();
        }

        private void OnDrawGizmos()
        {
            OnDrawGizmosSelected();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackDistance);
            
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }

        private float FindDistanceFromPlayer()
        {
            return Vector2.Distance(transform.position, player.transform.position);
        }
    }
}