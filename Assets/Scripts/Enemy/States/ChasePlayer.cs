using System.Collections;
using System.Collections.Generic;
using KingdomOfHope.Controller;
using KingdomOfHope.Movement;
using UnityEngine;
using KingdomOfHope.StateMachines;

namespace KingdomOfHope.Enemy.States
{
    public class ChasePlayer : IState
    {
        private IEntityController enemy;
        private IEntityController player;
        private IMover mover;
        private IFlipFace flipFace;
        private IAnimation animations;

        public ChasePlayer(IEntityController enemy, IEntityController player, IMover mover, IFlipFace flipFace, IAnimation aniamtions)
        {
            this.enemy = enemy;
            this.player = player;
            this.mover = mover;
            this.flipFace = flipFace;
            animations = aniamtions;
        }
        
        public void Tick()
        {
            Vector3 lefOrRight = player.transform.position - enemy.transform.position;
            var upOrDown = player.transform.position.y - enemy.transform.position.y;

            if (lefOrRight.x > 0.1)
            {
                mover.Move(1.2f, upOrDown);
                flipFace.FlipingFace(1f);
            }
            else
            {
                mover.Move(-1.2f, upOrDown);
                flipFace.FlipingFace(-1f);
            }

            Debug.Log("Enemy ChasePlayer / Tick");
        }

        public void OnEnter()
        {
            animations.MoveAnimation(true);
        }

        public void OnExit()
        {
            animations.MoveAnimation(false);
        }
    }   
}