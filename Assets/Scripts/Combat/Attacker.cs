using UnityEngine;

namespace KingdomOfHope.Combats
{
    public class Attacker : MonoBehaviour, IAttacker
    {
        [SerializeField] private float damage;
        
        public float Damage => damage;
        
        public virtual void Attack(ITakeHit takeHit)
        {
            takeHit.TakeHit(this);
        }
    }
}