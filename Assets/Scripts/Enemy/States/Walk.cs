using System.Collections;
using System.Collections.Generic;
using KingdomOfHope.Controller;
using KingdomOfHope.Movement;
using UnityEngine;
using KingdomOfHope.StateMachines;

namespace KingdomOfHope.Enemy.States
{
    public class Walk : IState
    {
        private IEntityController entityController;
        private IMover mover;
        private IFlipFace flipFace;
        private IAnimation animations;
        private Transform[] patrols;
        private Transform currentPatrol;
        private int patrolIndex = 0;
        private float direction = 1f;

        public bool IsWalking { get; private set; }

        public Walk(IEntityController entityController, IMover mover, IFlipFace flipFace, IAnimation animations, params Transform[] patrols)
        {
            this.entityController = entityController;
            this.mover = mover;
            this.flipFace = flipFace;
            this.animations = animations;
            this.patrols = patrols;
        }
        
        public void Tick()
        {
            if (Vector2.Distance(entityController.transform.position, currentPatrol.transform.position) <= 0.1f)
            {
                IsWalking = false;
                return;
            }
            
            mover.Move(direction, 0);
            
            Debug.Log("Enemy Walk / Tick");
        }

        public void OnEnter()
        {
            direction = entityController.transform.localScale.x;
            currentPatrol = patrols[patrolIndex];
            animations.MoveAnimation(true);
            IsWalking = true;
        }

        public void OnExit()
        {
            animations.MoveAnimation(false);
            
            patrolIndex++;
            if (patrolIndex >= patrols.Length)
                patrolIndex = 0;
            currentPatrol = patrols[patrolIndex];
        }
    }   
}