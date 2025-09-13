using Assets.Codebase.GameLogic.Common.AttackBehavior.Interface;
using Assets.Codebase.GameLogic.Common.HealthBehavior.Interface;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.AttackBehavior
{
    public class DamageService : IDamageService
    {
        private const int BufferSize = 6;
        private Collider2D[] _hits = new Collider2D[BufferSize];

        public void Attack(GameObject attacker, int damage, Vector3 origin, float radius)
        {
            foreach (IDamageable target in GetTargets(attacker, origin, radius))
            {
                target.TakeDamage(damage);
            }
        }

        private IDamageable[] GetTargets(GameObject attacker, Vector3 origin, float radius)
        {
            Vector2 center = new Vector2(origin.x, origin.y);

            List<IDamageable> targets = new List<IDamageable>();

            Physics2D.OverlapCircleNonAlloc(center, radius, _hits);

            foreach (Collider2D hit in _hits)
            {
                if (IsTargetFor(attacker, hit, out IDamageable target))
                {
                    targets.Add(target);
                }
            }

            return targets.Distinct().ToArray();
        }

        private bool IsTargetFor(GameObject attacker, Collider2D hit, out IDamageable target)
        {
            if (hit != null && !hit.isTrigger && hit.transform.gameObject != null)
            {
                return hit.transform.TryGetComponent(out target) && hit.transform.gameObject != attacker;
            }

            target = null;

            return false;
        }
    }
}
