using Assets.Codebase.GameLogic.Common.Actor.Enemy;
using Assets.Codebase.GameLogic.Common.Ground;
using Assets.Codebase.GameLogic.Common.MovementBehavior;
using UnityEngine;


namespace Assets.Codebase.GameLogic.Common.AI.Nodes.Implementation
{
    public class Move
    {
        private const float PlatformEdgeStoppingDistance = 1.0f;
        
        private GroundChecker _groundChecker;
        private MovementCalculator _movementCalculator;
        private EnemyMovement _characterMovement;


        public Move(EnemyComponent character, GroundChecker groundChecker, MovementCalculator movementCalculator) 
        { 
            _groundChecker = groundChecker;
            _movementCalculator = movementCalculator;

            character.TryGetComponent(out _characterMovement);
        }

        public Status Evaluate(Vector3 direction)
        {
            if (IsMovementAvailable(_characterMovement.transform.position, direction, _characterMovement.MovementSpeed))
            {
                _characterMovement.Move(direction);

                return Status.Success;
            }
            else 
            {
                _characterMovement.Move(Vector3.zero);
                return Status.Failure;
            }
        }

        private bool IsMovementAvailable(Vector3 position, Vector3 direction, float speed)
        {
            Vector3 predictedPosition = position + _movementCalculator.EvaluateMovement(direction, speed);

            predictedPosition = AvoidPlatformEdges(direction, predictedPosition);

            return _groundChecker.CheckGround(predictedPosition);
        }

        private static Vector3 AvoidPlatformEdges(Vector3 direction, Vector3 predictedPosition)
        {
            if (direction.x < 0)
            {
                predictedPosition.x -= PlatformEdgeStoppingDistance;
            }
            else if (direction.x > 0)
            {
                predictedPosition.x += PlatformEdgeStoppingDistance;
            }

            return predictedPosition;
        }
    }
}
