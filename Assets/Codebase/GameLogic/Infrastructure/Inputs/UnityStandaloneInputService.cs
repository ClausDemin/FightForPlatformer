using Assets.Codebase.GameLogic.Infrastructure.Inputs.Interface;
using UnityEngine;


namespace Assets.Codebase.GameLogic.Infrastructure.Inputs
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
