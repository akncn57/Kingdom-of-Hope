using UnityEngine;

namespace KingdomOfHope.Movement
{
    public class FlipWithTransform : IFlipFace
    {
        private Transform transform;

        public FlipWithTransform(Transform transform)
        {
            this.transform = transform;
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