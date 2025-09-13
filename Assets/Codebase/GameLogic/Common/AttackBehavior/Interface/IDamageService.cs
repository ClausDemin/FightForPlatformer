using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.AttackBehavior.Interface
{
    public interface IDamageService
    {
        public void PerformAttack(IAttacker attacker, int damage, Vector3 origin, float radius);
    }
}
