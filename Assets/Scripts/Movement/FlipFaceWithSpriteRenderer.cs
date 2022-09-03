using UnityEngine;

namespace KingdomOfHope.Movement
{
    public class FlipFaceWithSpriteRenderer : IFlipFace
    {
        private float horizontal;
        private SpriteRenderer sprite;
        
        /// <summary>
        ///  This constructor get horizontal movement value and flip face.
        /// </summary>
        /// <param name="horizontal"> Get horizontal movement. </param>
        /// <param name="sprite"> Get sprite to flip. </param>
        public FlipFaceWithSpriteRenderer(float horizontal, SpriteRenderer sprite)
        {
            this.horizontal = horizontal;
            this.sprite = sprite;
        }
        
        /// <summary>
        ///  This method fliping face by horizontal move value.
        /// </summary>
        /// <param name="horizontal"> Get horizontal movement value. </param>
        /// <param name="sprite"> Get sprite component. </param>
        public void FlipingFace(float horizontal)
        {
            if (horizontal < 0)
                sprite.flipX = true;
            if (horizontal > 0)
                sprite.flipX = false;
        }
    }
}