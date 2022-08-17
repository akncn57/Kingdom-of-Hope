using UnityEngine;

namespace KingdomOfHope.Movement
{
    public class FlipFace : IFlipFace
    {
        /// <summary>
        ///  This method fliping face by horizontal move value.
        /// </summary>
        /// <param name="horizontal"> Get horizontal movement value. </param>
        /// <param name="sprite"> Get sprite component. </param>
        public void FlipingFace(float horizontal, SpriteRenderer sprite)
        {
            if (horizontal < 0)
                sprite.flipX = true;
            if (horizontal > 0)
                sprite.flipX = false;
        }
    }
}