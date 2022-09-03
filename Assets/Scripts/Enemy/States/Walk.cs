using System.Collections;
using System.Collections.Generic;
using KingdomOfHope.Movement;
using UnityEngine;
using KingdomOfHope.StateMachines;

namespace KingdomOfHope.Enemy.States
{
    public class Walk : IState
    {
        private IMover mover;
        private IFlipFace flipFace;
        private Transform[] patrols;
        private float direction = 1f;

        public bool IsWalking { get; private set; }

        public Walk(IMover mover, IFlipFace flipFace, params Transform[] patrols)
        {
            this.mover = mover;
            this.flipFace = flipFace;
            this.patrols = patrols;
        }
        
        public void Tick()
        {
            mover.Move(direction, 0);
            
            Debug.Log("Enemy Walk / Tick");
        }

        public void OnEnter()
        {
            IsWalking = true;
            
            Debug.Log("Enemy Walk / OnEnter");
        }

        public void OnExit()
        {
            direction *= -1;
            flipFace.FlipingFace(direction);
            IsWalking = false;
            
            Debug.Log("Enemy Walk / OnExit");
        }
    }   
}