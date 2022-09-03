using UnityEngine;

namespace KingdomOfHope.Movement
{
    public class FlipWithTransform : IFlipFace
    {
        private Transform transform;
        private float direction;
        
        public FlipWithTransform(Transform transform, float direction)
        {
            this.transform = transform;
            this.direction = direction;
        }

        public void FlipingFace(float direction)
        {
            if (direction == 0f) return;

            float mathValue = Mathf.Sign(direction);

            if(mathValue != transform.localScale.x)
            {
                transform.localScale = new Vector2(mathValue, 1f);
            }
        }
    }
}