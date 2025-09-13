using Assets.Codebase.GameLogic.Common.MovementBehavior.Enum;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.Actor.Enemy.Animation
{
    public class EnemyAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _enemyAnimator;

        private void Awake()
        {
            _enemyAnimator.SetBool(EnemyAnimatorData.IsAlive, true);
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

        public void SetGrounded(bool isGrounded) 
        {
            _enemyAnimator.SetBool(EnemyAnimatorData.IsGrounded, isGrounded);
        }
        
        public void SetHasEnemy(bool hasEnemy) 
        {
            _enemyAnimator.SetBool(EnemyAnimatorData.HasEnemy, hasEnemy);
        }

        public void PlayHitAnimation() 
        {
            _enemyAnimator.SetTrigger(EnemyAnimatorData.Damaged);
        }

        public void PlayDeathAnimation() 
        {
            _enemyAnimator.SetBool(EnemyAnimatorData.IsAlive, false);
        }

        public void PlayAttackAnimation() 
        {
            _enemyAnimator.SetTrigger(EnemyAnimatorData.Attack);
        }

        private void PlayMoveAnimation()
        {
            _enemyAnimator.SetBool(EnemyAnimatorData.IsMoving, true);
        }

        private void StopMoveAnimation()
        {
            _enemyAnimator.SetBool(EnemyAnimatorData.IsMoving, false);
        }
    }
}
