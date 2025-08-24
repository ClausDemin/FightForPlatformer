using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.MovementBehavior.Interface
{
    public interface IMovementService
    {
        public void Move(Rigidbody2D actor, Vector3 direction, float speed);
        public void Jump(Rigidbody2D actor, float jumpForce);
    }
}
