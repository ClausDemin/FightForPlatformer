using Assets.Codebase.GameLogic.Common.Actor.Enemy;
using Assets.Codebase.GameLogic.Common.AttackBehavior;
using Assets.Codebase.GameLogic.Common.HealthBehavior.Interface;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.AI.Nodes.Implementation
{
    public class Attack : Node
    {
        private EnemyComponent _character;
        private AttackComponent _attack;

        public Attack(EnemyComponent character)
        {
            _character = character;
            _character.TryGetComponent(out _attack);
        }

        public override Status Evaluate()
        {
            _attack.TryStartAttack();

            return Status.Success;
        }
    }
}
