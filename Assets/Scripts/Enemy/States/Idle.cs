using System.Collections;
using System.Collections.Generic;
using KingdomOfHope.Movement;
using UnityEngine;
using KingdomOfHope.StateMachines;
using Random = UnityEngine.Random;

namespace KingdomOfHope.Enemy.States
{
    public class Idle : IState
    {
        private IMover mover;
        private float maxStandTime;
        private float currentStandTime = 0f;

        public bool IsIdle { get; private set; }
        
        public Idle(IMover mover)
        {
            this.mover = mover;
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
            //TODO: Idle animasyonunu burada bir şekilde oynat.
            maxStandTime = Random.Range(4f, 10f);
            
            Debug.Log("Enemy Idle / OnEnter");
        }

        public void OnExit()
        {
            currentStandTime = 0f;

            Debug.Log("Enemy Idle / OnExit");
        }
    }   
}