using UnityEngine;

namespace Animation
{
    public class CharacterAnimations : IAnimation
    {
        private Animator animator;

        public CharacterAnimations(Animator animator)
        {
            this.animator = animator;
        }
        
        public void MoveAnimation(bool isWalking)
        {
            animator.SetBool("isMoving", isWalking);
        }

        public void AttackAnimation()
        {
            animator.SetTrigger("attack");
        }

        public void TakeHitAnimation()
        {
            throw new System.NotImplementedException();
        }

        public void DeadAnimation()
        {
            throw new System.NotImplementedException();
        }
    }
}