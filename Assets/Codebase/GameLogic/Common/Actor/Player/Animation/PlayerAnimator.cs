using Assets.Codebase.GameLogic.Common.MovementBehavior.Enum;
using System;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.Actor.Player.Animation
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void Awake()
        {
            _animator.SetBool(PlayerAnimatorData.IsAlive, true);
        }

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

        public void PlayHitAnimation()
        {
            if (_animator != null)
            {
                _animator.SetTrigger(PlayerAnimatorData.Damaged);
            }
        }

        public void PlayDeathAnimation() 
        {
            if (_animator != null)
            {
                _animator.SetBool(PlayerAnimatorData.IsAlive, false);
            }
        }

        public void PlayAttackAnimation()
        {
            if (_animator != null) 
            {
                _animator.SetTrigger(PlayerAnimatorData.Attack);
            }
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
