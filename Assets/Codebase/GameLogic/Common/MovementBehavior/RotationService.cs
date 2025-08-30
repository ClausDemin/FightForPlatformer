using Assets.Codebase.GameLogic.Common.MovementBehavior.Enum;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.MovementBehavior
{
    public class RotationService
    {
        private Dictionary<MovementDirection, Vector3> _direction;

        public RotationService()
        {
            _direction = new Dictionary<MovementDirection, Vector3>()
            {
                { MovementDirection.Right, Vector3.right },
                { MovementDirection.Left, Vector3.left },
            };
        }

        public void RotateFaceToDirection(Transform transform, MovementDirection direction) 
        {
            if (direction != MovementDirection.None) 
            { 
                transform.right = _direction[direction];
            }
        }
    }
}
