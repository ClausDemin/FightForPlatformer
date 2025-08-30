using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.JumpBehavior.Interface
{
    public interface IJumpService
    {
        public void Jump(Rigidbody2D actor, float jumpForce);
    }
}
