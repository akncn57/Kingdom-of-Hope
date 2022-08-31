using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KingdomOfHope.StateMachines;

namespace KingdomOfHope.Enemy.States
{
    public class ChasePlayer : IState
    {
        public void Tick()
        {
            Debug.Log("Enemy ChasePlayer / Tick");
        }

        public void OnEnter()
        {
            Debug.Log("Enemy ChasePlayer / OnEnter");
        }

        public void OnExit()
        {
            Debug.Log("Enemy ChasePlayer / OnExit");
        }
    }   
}