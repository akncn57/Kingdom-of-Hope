using UnityEngine;
using KingdomOfHope.Combats;

public class Attacker : IAttacker
{
    private Transform attackDirection;
    private float attackRadius;
    
    public void Attack()
    {
        Debug.Log("Player Attacking !!!");
    }
    
    private void OnDrawGizmos()
    {
        OnDrawGizmosSelected();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackDirection.position + attackDirection.forward, attackRadius);
    }
}
