using System.Collections;
using System.Collections.Generic;
using KingdomOfHope.Movement;
using UnityEngine;
using KingdomOfHope.StateMachines;

namespace KingdomOfHope.Enemy.States
{
    public class Walk : IState
    {
        private Transform enemyTransform;
        private IMover mover;
        private IFlipFace flipFace;
        private IAnimation animations;
        private Transform[] patrols;
        private Transform currentPatrol;
        private int patrolIndex = 0;
        private float direction = 1f;

        public bool IsWalking { get; private set; }

        public Walk(Transform enemyTransform, IMover mover, IFlipFace flipFace, IAnimation animations, params Transform[] patrols)
        {
            this.enemyTransform = enemyTransform;
            this.mover = mover;
            this.flipFace = flipFace;
            this.animations = animations;
            this.patrols = patrols;
        }
        
        public void Tick()
        {
            if (Vector2.Distance(enemyTransform.position, currentPatrol.transform.position) <= 0.2f)
            {
                IsWalking = false;
                return;
            }
            
            mover.Move(direction, 0);
            
            Debug.Log("Enemy Walk / Tick");
        }

        public void OnEnter()
        {
            currentPatrol = patrols[patrolIndex];
            animations.MoveAnimation(true);
            IsWalking = true;
        }

        public void OnExit()
        {
            direction *= -1;
            flipFace.FlipingFace(direction);
            animations.MoveAnimation(false);
            
            patrolIndex++;
            if (patrolIndex >= patrols.Length)
                patrolIndex = 0;
            currentPatrol = patrols[patrolIndex];
        }
    }   
}