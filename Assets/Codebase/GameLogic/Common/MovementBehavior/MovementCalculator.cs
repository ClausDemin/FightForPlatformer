using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.MovementBehavior
{
    public class MovementCalculator 
    {
        public Vector3 EvaluateMovement(Vector3 direction, float speed) 
        { 
            return direction * speed * Time.fixedDeltaTime;
        }
    }
}
