using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KingdomOfHope.Inputs
{
    public interface IPlayerInput
    {
        float Horizontal { get; }
        float Vertical { get; }
        bool AttackButtonDown { get; }
    }
}