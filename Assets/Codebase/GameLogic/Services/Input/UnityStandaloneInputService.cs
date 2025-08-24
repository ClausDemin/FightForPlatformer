using Assets.Codebase.GameLogic.Services.InputService.Core;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Services.InputService
{
    public class UnityStandaloneInputService : IInputService
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";

        public Vector2 Axles => new Vector2(Input.GetAxisRaw(HorizontalAxis), Input.GetAxisRaw(VerticalAxis));

        public float Horizontal => Axles.x;
        public float Vertical => Axles.y;

        public bool IsAttackButtonDown()
        {
            return Input.GetMouseButtonDown(0);
        }

        public bool IsJumpButtonDown()
        {
            return Input.GetKey(KeyCode.Space);
        }
    }
}
