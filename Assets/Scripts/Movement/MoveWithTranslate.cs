using UnityEditor.Build.Reporting;
using UnityEngine;

namespace KingdomOfHope.Movement
{
    public class MoveWithTranslate : IMover
    {
        private float speed;
        private Transform transform;

        public MoveWithTranslate(float speed, Transform transform)
        {
            this.speed = speed;
            this.transform = transform;
        }
        
        public void Move(float horizontal, float vertical)
        {
            transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed);
        }
    }
}