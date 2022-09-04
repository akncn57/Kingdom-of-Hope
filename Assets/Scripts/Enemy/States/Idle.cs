using System.Collections;
using System.Collections.Generic;
using KingdomOfHope.Controller;
using KingdomOfHope.Movement;
using UnityEngine;
using KingdomOfHope.StateMachines;
using Random = UnityEngine.Random;

namespace KingdomOfHope.Enemy.States
{
    public class Idle : IState
    {
        private IMover mover;
        private IAnimation animations;
        private IFlipFace flipFace;
        private IEntityController entityController;
        
        private float maxStandTime;
        private float currentStandTime = 0f;

        public bool IsIdle { get; private set; }
        
        public Idle(IEntityController entityController, IMover mover, IAnimation aniamtions, IFlipFace flipFace)
        {
            this.mover = mover;
            this.animations = aniamtions;
            this.entityController = entityController;
            this.flipFace = flipFace;
        }
            
        public void Tick()
        {
            mover.Move(0f, 0f);
            currentStandTime += Time.deltaTime;
            if (currentStandTime > maxStandTime) IsIdle = false;
            
            Debug.Log("Enemy Idle / Tick");
        }

        public void OnEnter()
        {
            IsIdle = true;
            animations.MoveAnimation(false);
            maxStandTime = Random.Range(4f, 10f);
        }

        public void OnExit()
        {
            currentStandTime = 0f;
            flipFace.FlipingFace(entityController.transform.localScale.x * -1);
        }
    }   
}