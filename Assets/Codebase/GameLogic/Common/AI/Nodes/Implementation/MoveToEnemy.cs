using Assets.Codebase.GameLogic.Common.Actor.Enemy;
using Assets.Codebase.GameLogic.Common.AttackBehavior;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.AI.Nodes.Implementation
{
    public class MoveToEnemy : Node
    {
        private EnemyComponent _character;
        private AttackComponent _attack;

        private Move _moveBehavior;

        public MoveToEnemy(EnemyComponent character, Move moveBehavior)
        {
            _character = character;
            _moveBehavior = moveBehavior;
            _character.TryGetComponent(out _attack);
        }

        public override Status Evaluate()
        {
            if (_attack != null) 
            {
                if (EvaluateDistance() > _attack.Radius)
                {
                    if (CanMove())
                    {
                        return Status.Running;
                    }
                    else
                    {
                        return Status.Failure;
                    }
                }
                else
                {
                    _moveBehavior.Evaluate(Vector3.zero);

                    return Status.Success;
                }
            }

            return Status.Failure;
        }

        private bool CanMove()
        {
            return _moveBehavior.Evaluate(GetDirection()) == Status.Success;
        }

        private Vector3 GetDirection()
        {
            Vector3 target = _character.Target.transform.position - _character.transform.position;

            return new Vector3(target.x, 0, 0).normalized;
        }

        private float EvaluateDistance()
        {
            Vector3 horizontal = new Vector3(_character.Target.transform.position.x - _character.transform.position.x, 0, 0);

            return horizontal.magnitude;
        }
    }
}
