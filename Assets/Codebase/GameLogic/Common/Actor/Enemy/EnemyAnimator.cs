using Assets.Codebase.GameLogic.Common.MovementBehavior;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.Actor.Enemy
{
    public class EnemyAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _enemyAnimator;

        private readonly int MoveHash = Animator.StringToHash("IsMoving");
        private readonly int GroundedHash = Animator.StringToHash("IsGrounded");
        private readonly int HasEnemyHash = Animator.StringToHash("HasEnemy");

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
            _enemyAnimator.SetBool(MoveHash, true);
        }

        private void StopMoveAnimation() 
        {
            _enemyAnimator.SetBool(MoveHash, false);
        }

        public void SetGrounded(bool isGrounded) 
        {
            _enemyAnimator.SetBool(GroundedHash, isGrounded);
        }

        public void SetHasEnemy(bool hasEnemy) 
        {
            _enemyAnimator.SetBool(HasEnemyHash, hasEnemy);
        }
    }
}
