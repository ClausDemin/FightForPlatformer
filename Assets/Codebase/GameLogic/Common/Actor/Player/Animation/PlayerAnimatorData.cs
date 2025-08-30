using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.Actor.Player.Animation
{
    public static class PlayerAnimatorData
    {
        public static readonly int IsMoving = Animator.StringToHash(nameof(IsMoving));
        public static readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));
        public static readonly int Jump = Animator.StringToHash(nameof(Jump));
        public static readonly int Attack = Animator.StringToHash(nameof(Attack));
        public static readonly int Damaged = Animator.StringToHash(nameof(Damaged));
        public static readonly int Die = Animator.StringToHash(nameof(Die));
    }
}
