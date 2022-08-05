using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KingdomOfHope.Inputs;

public class PcInputs : IPlayerInput
{
    public float Horizontal => Input.GetAxis("Horizontal");
    public float Vertical => Input.GetAxis("Vertical");
    public bool AttackButtonDown => Input.GetButtonDown("Fire1");
}
