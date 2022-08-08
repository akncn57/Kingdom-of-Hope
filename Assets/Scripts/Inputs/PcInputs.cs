using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KingdomOfHope.Inputs;

public class PcInputs : IPlayerInput
{
    public float Horizontal => Input.GetAxisRaw("Horizontal");
    public float Vertical => Input.GetAxisRaw("Vertical");
    public bool AttackButtonDown => Input.GetButtonDown("Fire1");
}
