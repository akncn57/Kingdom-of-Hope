using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KingdomOfHope.StateMachines;

namespace KingdomOfHope.Enemy.States
{
    public class Idle : IState
    {
        public void Tick()
        {
            Debug.Log("Enemy Idle / Tick");
        }

        public void OnEnter()
        {
            Debug.Log("Enemy Idle / OnEnter");
        }

        public void OnExit()
        {
            Debug.Log("Enemy Idle / OnExit");
        }
    }   
}