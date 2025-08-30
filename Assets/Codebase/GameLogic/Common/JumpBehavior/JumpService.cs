using Assets.Codebase.GameLogic.Common.JumpBehavior.Interface;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.JumpBehavior
{
    public class JumpService : IJumpService
    {
        public void Jump(Rigidbody2D actor, float jumpForce)
        {
            actor.velocity = Vector3.up * jumpForce;
        }
    }
}
