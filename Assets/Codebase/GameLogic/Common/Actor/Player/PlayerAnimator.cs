using Assets.Codebase.GameLogic.Common.MovementBehavior;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.Actor.Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private readonly int MoveHash = Animator.StringToHash("IsMoving");
        private readonly int GroundedHash = Animator.StringToHash("IsGrounded");
        private readonly int JumpHash = Animator.StringToHash("Jump");
        private readonly int AttackHash = Animator.StringToHash("Attack");
        private readonly int DamagedHash = Animator.StringToHash("Damaged");
        private readonly int DieHash = Animator.StringToHash("Die");

        public void SwitchMovementAnimation(MovementDirection direction)
        {
            if (direction != MovementDirection.None)
            {
                PlayMoveAnimation();
            }
            else
            {
                StopMoveAnimation();
            }
        }

        public void PlayJumpAnimation()
        {
            if (_animator != null)
            {
                _animator.SetTrigger(JumpHash);
            }
        }

        public void SetGroundedFlag(bool isGrounded)
        {
            _animator.SetBool(GroundedHash, isGrounded);
        }

        private void PlayMoveAnimation()
        {
            if (_animator != null)
            {
                _animator.SetBool(MoveHash, true);
            }
        }

        private void StopMoveAnimation()
        {
            if (_animator != null)
            {
                _animator.SetBool(MoveHash, false);
            }
        }
    }
}
