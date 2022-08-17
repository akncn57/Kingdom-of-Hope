using UnityEditor.Build.Reporting;
using UnityEngine;

namespace KingdomOfHope.Movement 
{
    public class MoveWithMovePosition : IMover
    {
        private float speed;
        private Rigidbody2D rigidbody;
        private Vector2 movementDirection;

        /// <summary>
        ///  This constructor get movement speed and rigidbody.
        /// </summary>
        /// <param name="speed"> Get movement speed. </param>
        /// <param name="rigidbody"> Get rigidbody to move. </param>
        public MoveWithMovePosition(float speed, Rigidbody2D rigidbody)
        {
            this.speed = speed;
            this.rigidbody = rigidbody;
        }
        
        /// <summary>
        ///  This method allows movement by changing the rigidbody position.
        /// </summary>
        /// <param name="horizontal"> Get horizontal movement value. </param>
        /// <param name="vertical"> Get vertical. movement value. </param>
        public void Move(float horizontal, float vertical)
        {
            movementDirection.x = horizontal;
            movementDirection.y = vertical;
            rigidbody.MovePosition(rigidbody.position + movementDirection.normalized * (speed * Time.fixedDeltaTime));
        }
    }
}