using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [SerializeField] private Collider2D swordCollider;
    private Vector2 rightAttackOffset;

    private void Start()
    {
        // Get default position of attack offset.
        rightAttackOffset = transform.position;
    }

    public void AttackRight()
    {
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }

    public void AttackLeft()
    {
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    public void StopAttack()
    {
        swordCollider.enabled = false;
    }
}
