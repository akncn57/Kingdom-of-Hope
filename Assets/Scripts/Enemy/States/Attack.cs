using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KingdomOfHope.StateMachines;

namespace KingdomOfHope.Enemy.States
{
    public class Attack : IState
    {
        private IAnimation animations;
        
        public Attack(IAnimation animations)
        {
            this.animations = animations;
        }
        
        public void Tick()
        {
            animations.AttackAnimation();
            
            Debug.Log("Enemy Attack / Tick");
        }

        public void OnEnter()
        {
            Debug.Log("Enemy Attack / OnEnter");
        }

        public void OnExit()
        {
            Debug.Log("Enemy Attack / OnExit");
        }
    }   
}