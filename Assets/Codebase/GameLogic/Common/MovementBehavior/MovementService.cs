using Assets.Codebase.GameLogic.Common.MovementBehavior.Interface;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.MovementBehavior
{
    public class MovementService : IMovementService
    {
        private MovementCalculator _calculator;

        public MovementService(MovementCalculator calculator)
        {
            _calculator = calculator;
        }

        public void Move(Rigidbody2D actor, Vector3 direction, float speed)
        {
            actor.transform.position += _calculator.EvaluateMovement(direction, speed);
        }
    }
}
