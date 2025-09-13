using Assets.Codebase.GameLogic.Common.Actor.Enemy;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.AI.Nodes.Implementation
{
    public class ReturnToSpawnPoint : Node
    {
        private const float DestinationTolerance = 0.25f;

        private EnemyComponent _character;
        private Move _move;
        private Vector3 _spawnPoint;

        public ReturnToSpawnPoint(EnemyComponent character, Move move)
        {
            _character = character;
            _move = move;

            _spawnPoint = _character.transform.position;
        }

        public override Status Evaluate()
        {
            if (IsSpawnPointReached())
            {
                return Status.Success;
            }
            else
            {
                if (CanMove())
                {
                    return Status.Running;
                }
            }

            return Status.Failure;
        }

        private bool CanMove()
        {
            return _move.Evaluate(GetDirection()) == Status.Success;
        }

        private bool IsSpawnPointReached()
        {
            float distance = (_spawnPoint - _character.transform.position).magnitude;

            return distance < DestinationTolerance;
        }

        private Vector3 GetDirection()
        {
            return (_spawnPoint - _character.transform.position).normalized;
        }
    }
}
