using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KingdomOfHope.Combats
{
    public interface ITakeHit
    {
        void TakeHit(IAttacker attacker);
    }
}