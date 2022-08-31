using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KingdomOfHope.StateMachines;

namespace KingdomOfHope.Enemy.States
{
    public class Walk : IState
    {
        public void Tick()
        {
            Debug.Log("Enemy Walk / Tick");
        }

        public void OnEnter()
        {
            Debug.Log("Enemy Walk / OnEnter");
        }

        public void OnExit()
        {
            Debug.Log("Enemy Walk / OnExit");
        }
    }   
}