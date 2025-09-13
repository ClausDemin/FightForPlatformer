namespace Assets.Codebase.GameLogic.Common.HealthBehavior.Interface
{
    public interface IDamageable
    {
        public void TakeDamage(int damage);

        public bool IsAlive { get; }
    }
}
