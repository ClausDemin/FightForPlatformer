using Assets.Codebase.GameLogic.Common.Actor.Enemy;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.AI.Nodes.Implementation
{
    public class MoveToEnemy : Node
    {
        private EnemyComponent _character;

        private Move _moveBehavior;


        public MoveToEnemy(EnemyComponent character, Move moveBehavior)
        {
            _character = character;
            _moveBehavior = moveBehavior;
        }

        public override Status Evaluate()
        {
            if (EvaluateSquareDistance() > 1.0f)
            {
                if (_moveBehavior.Evaluate(GetDirection()) == Status.Success)
                {
                    return Status.Running;
                }
                else 
                {
                    return Status.Success;
                }
            }
            else 
            {
                return _moveBehavior.Evaluate(Vector3.zero);
            }
        }

        private Vector3 GetDirection()
        {
            Vector3 target = _character.Target.transform.position - _character.transform.position;

            return new Vector3(target.x, 0, 0).normalized;
        }

        private float EvaluateSquareDistance()
        {
            Vector3 horizontal = new Vector3(_character.Target.transform.position.x - _character.transform.position.x, 0, 0);

            return horizontal.sqrMagnitude;
        }
    }
}
