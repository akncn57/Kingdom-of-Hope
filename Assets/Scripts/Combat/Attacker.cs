using UnityEngine;
using KingdomOfHope.Combats;

public class Attacker : IAttacker
{
    private Transform attackDirection;
    private float attackRadius;
    
    /// <summary>
    ///  This constructor get attack direction and attack radius.
    /// </summary>
    /// <param name="attackDirection"> Get transform of attack direction. </param>
    /// <param name="attackRadius"> Get attack radius value. </param>
    public Attacker(Transform attackDirection, float attackRadius)
    {
        this.attackDirection = attackDirection;
        this.attackRadius = attackRadius;
    }
    
    public void Attack()
    {
        Debug.Log("Player Attacking !!!");
    }
    
    // private void OnDrawGizmos()
    // {
    //     OnDrawGizmosSelected();
    // }
    //
    // private void OnDrawGizmosSelected()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(attackDirection.position + attackDirection.forward, attackRadius);
    // }
}
