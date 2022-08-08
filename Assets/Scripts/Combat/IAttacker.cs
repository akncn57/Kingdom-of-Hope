namespace KingdomOfHope.Combats
{
    public interface IAttacker
    {
        float Damage { get; }
        void Attack(ITakeHit takeHit);
    }
}