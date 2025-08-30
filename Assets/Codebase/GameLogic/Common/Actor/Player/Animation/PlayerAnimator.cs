using Assets.Codebase.GameLogic.Common.MovementBehavior.Enum;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.Actor.Player.Animation
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

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
                _animator.SetTrigger(PlayerAnimatorData.Jump);
            }
        }

        public void SetGroundedFlag(bool isGrounded)
        {
            _animator.SetBool(PlayerAnimatorData.IsGrounded, isGrounded);
        }

        private void PlayMoveAnimation()
        {
            if (_animator != null)
            {
                _animator.SetBool(PlayerAnimatorData.IsMoving, true);
            }
        }

        private void StopMoveAnimation()
        {
            if (_animator != null)
            {
                _animator.SetBool(PlayerAnimatorData.IsMoving, false);
            }
        }
    }
}
