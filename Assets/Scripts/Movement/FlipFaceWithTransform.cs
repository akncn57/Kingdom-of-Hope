using KingdomOfHope.Controller;
using UnityEngine;

namespace KingdomOfHope.Movement
{
    public class FlipWithTransform : IFlipFace
    {
        private IEntityController entityController;

        public FlipWithTransform(IEntityController entityController)
        {
            this.entityController = entityController;
        }

        public void FlipingFace(float direction)
        {
            if (direction == 0f) return;

            float mathValue = Mathf.Sign(direction);

            if(mathValue != entityController.transform.localScale.x)
            {
                entityController.transform.localScale = new Vector2(mathValue, 1f);
            }
        }
    }
}