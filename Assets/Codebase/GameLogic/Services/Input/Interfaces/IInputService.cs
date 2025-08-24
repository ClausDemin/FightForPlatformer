using UnityEngine;

namespace Assets.Codebase.GameLogic.Services.InputService.Core
{
    public interface IInputService
    {
        public Vector2 Axles { get; }
        public float Horizontal => Axles.x;
        public float Vertical => Axles.y;

        public bool IsAttackButtonDown();

        public bool IsJumpButtonDown();
    }
}
