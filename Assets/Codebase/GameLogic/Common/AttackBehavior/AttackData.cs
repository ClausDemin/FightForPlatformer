namespace Assets.Codebase.GameLogic.Common.AttackBehavior
{
    public class AttackData
    {
        public AttackData(int damage, float attackRadius, float cooldown)
        {
            Damage = damage;
            Radius = attackRadius;
            Cooldown = cooldown;
        }

        public int Damage { get; private set; }
        public float Radius { get; private set; }
        public float Cooldown { get; private set; }
    }
}
