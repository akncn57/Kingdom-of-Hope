using System;
using System.Collections;
using System.Collections.Generic;
using KingdomOfHope.Enemy.States;
using UnityEngine;
using KingdomOfHope.Movement;
using KingdomOfHope.StateMachines;

namespace KingdomOfHope.Controller
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float chaseDistance;
        [SerializeField] private float attackDistance;
        [SerializeField] private Transform player;
        [SerializeField] private bool isWalk = false;
        
        private MoveWithMovePosition mover;
        private Attacker attacker;
        private FlipFace flipFace;
        
        StateMachine stateMachine;
        
        private void Awake()
        {
            // mover = new MoveWithMovePosition(playerspeed, rigidbody);
            // attacker = new Attacker(attackDirection, attackRadius);
            // flipFace = new FlipFace(horizontal, sprite);
            stateMachine = new StateMachine();
        }

        private void Start()
        {
            Idle idle = new Idle();
            Walk walk = new Walk();
            ChasePlayer chasePlayer = new ChasePlayer();
            Dead dead = new Dead();
            TakeHit takeHit = new TakeHit();
            Attack attack = new Attack();
            
            stateMachine.AddTransition(idle, walk, () => isWalk);
            stateMachine.AddTransition(idle, chasePlayer, () => FindDistanceFromPlayer() < chaseDistance);
            stateMachine.AddTransition(walk, chasePlayer, () => FindDistanceFromPlayer() < chaseDistance);
            stateMachine.AddTransition(chasePlayer, attack, () => FindDistanceFromPlayer() < attackDistance);
            stateMachine.AddTransition(walk, idle, () => !isWalk);
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
        }

        private float FindDistanceFromPlayer()
        {
            return Vector2.Distance(transform.position, player.transform.position);
        }
    }
}