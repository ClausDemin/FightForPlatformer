using Assets.Codebase.GameLogic.Common.Actor.Enemy;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.AI.Nodes.Implementation
{
    public class Patrol : Node
    {
        private const float PatrolRadius = 2.0f;
        private const float DestinationTolerance = 0.25f;

        private Move _movementBehavior;
        private Transform _character;

        private Vector3 _spawnPoint;
        private Vector3 _currentDirection;
        private Vector3 _destinationPoint;

        public Patrol(EnemyComponent character, Move moveBehavior)
        {
            _movementBehavior = moveBehavior;
            _character = character.transform;

            _spawnPoint = character.transform.position;
            _currentDirection = Vector3.right;
            _destinationPoint = GetDestinationPoint(_spawnPoint, _currentDirection);
        }

        public override Status Evaluate()
        {
            if ((_destinationPoint - _character.position).magnitude > DestinationTolerance)
            {
                if (_movementBehavior.Evaluate(_currentDirection) == Status.Success) 
                {
                    return Status.Running;
                }

                return Status.Failure;
            }
            else 
            {
                SwitchDirection();
                _destinationPoint = GetDestinationPoint(_spawnPoint, _currentDirection);

                return Status.Success;
            }
        }

        private Vector3 GetDestinationPoint(Vector3 spawnPoint, Vector3 direction) 
        { 
            return spawnPoint + direction * PatrolRadius;
        }

        private void SwitchDirection() 
        { 
            _currentDirection = -1 * _currentDirection;
        }
    }
}
