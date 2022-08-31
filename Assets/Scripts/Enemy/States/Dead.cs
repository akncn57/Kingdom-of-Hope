using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KingdomOfHope.StateMachines;

namespace KingdomOfHope.Enemy.States
{
    public class Dead : IState
    {
        public void Tick()
        {
            Debug.Log("Enemy Dead / Tick");
        }

        public void OnEnter()
        {
            Debug.Log("Enemy Dead / OnEnter");
        }

        public void OnExit()
        {
            Debug.Log("Enemy Dead / OnExit");
        }
    }   
}