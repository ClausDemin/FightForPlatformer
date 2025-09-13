using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.AttackBehavior.Interface
{
    public interface IDamageService
    {
        public void Attack(GameObject attacker, int damage, Vector3 origin, float radius);
    }
}
