namespace Assets.Codebase.GameLogic.Common.AttackBehavior
{
    public class AttackData
    {
        public AttackData(int damage, float radius, float cooldown)
        {
            Damage = damage;
            Radius = radius;
            Cooldown = cooldown;
        }

        public int Damage { get; private set; }
        public float Radius { get; private set; }
        public float Cooldown { get; private set; }
    }
}
