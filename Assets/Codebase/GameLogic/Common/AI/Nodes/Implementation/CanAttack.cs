using Assets.Codebase.GameLogic.Common.Actor.Enemy;
using Assets.Codebase.GameLogic.Common.AI.Nodes.Core;
using Assets.Codebase.GameLogic.Common.AttackBehavior;
using Assets.Codebase.GameLogic.Common.HealthBehavior.Interface;

namespace Assets.Codebase.GameLogic.Common.AI.Nodes.Implementation
{
    public class CanAttack : Condition
    {
        private EnemyComponent _character;
        private AttackComponent _attack;

        public CanAttack(Node child, EnemyComponent character) : base(child)
        {
            _character = character;
            _character.TryGetComponent(out _attack);
        }

        protected override bool CanEvaluate()
        {
            return _attack != null && _character.Target.IsAlive && !_attack.IsInCooldown && IsTargetInRadius();
        }

        private bool IsTargetInRadius() 
        { 
            float distance = (_character.Target.transform.position - _character.transform.position).magnitude;

            return distance <= _attack.Radius;
        }
    }
}
