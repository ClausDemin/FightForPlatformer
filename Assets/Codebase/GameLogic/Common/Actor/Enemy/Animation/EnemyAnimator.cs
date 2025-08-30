using Assets.Codebase.GameLogic.Common.MovementBehavior.Enum;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.Actor.Enemy.Animation
{
    public class EnemyAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _enemyAnimator;

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

        private void PlayMoveAnimation() 
        {
            _enemyAnimator.SetBool(EnemyAnimatorData.IsMoving, true);
        }

        private void StopMoveAnimation() 
        {
            _enemyAnimator.SetBool(EnemyAnimatorData.IsMoving, false);
        }

        public void SetGrounded(bool isGrounded) 
        {
            _enemyAnimator.SetBool(EnemyAnimatorData.IsGrounded, isGrounded);
        }

        public void SetHasEnemy(bool hasEnemy) 
        {
            _enemyAnimator.SetBool(EnemyAnimatorData.HasEnemy, hasEnemy);
        }
    }
}
