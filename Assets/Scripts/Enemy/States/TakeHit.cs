using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KingdomOfHope.StateMachines;

namespace KingdomOfHope.Enemy.States
{
    public class TakeHit : IState
    {
        public void Tick()
        {
            Debug.Log("Enemy TakeHit / Tick");
        }

        public void OnEnter()
        {
            Debug.Log("Enemy TakeHit / OnEnter");
        }

        public void OnExit()
        {
            Debug.Log("Enemy TakeHit / OnExit");
        }
    }   
}