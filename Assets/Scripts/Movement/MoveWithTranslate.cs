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
            // movementDirection.x = horizontal;
            // movementDirection.y = vertical;
            //transform.Translate(rigidbody.position + movementDirection.normalized * (speed * Time.fixedDeltaTime));
            transform.Translate(horizontal * speed * Time.deltaTime,
                vertical * speed * Time.deltaTime, 0);
        }
    }
}