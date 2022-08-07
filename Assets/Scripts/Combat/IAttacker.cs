using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KingdomOfHope.Combats
{
    public interface IAttacker
    {
        float Damage { get; }
        void Attack(ITakeHit takeHit);
    }
}