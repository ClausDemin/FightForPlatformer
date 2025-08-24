using Assets.Codebase.GameLogic.Common.Actor.Player;
using Assets.Codebase.GameLogic.Common.AI;
using Assets.Codebase.GameLogic.Common.MovementBehavior;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.Actor.Enemy
{
    [RequireComponent(typeof(EnemyAnimator), typeof(EnemyMovement))]
    public class EnemyComponent : MonoBehaviour
    {
        private EnemyMovement _movementComponent;
        private EnemyAnimator _enemyAnimator;
        private BehaviorTree _aiActor;

        private SpriteRenderer _spriteRenderer;

        public void Init(BehaviorTree aiActor) 
        {
            _aiActor = aiActor;
        }

        public bool HasEnemy { get; private set; }
        public PlayerComponent Target { get; private set; }

        private void Awake()
        {
            _movementComponent = GetComponent<EnemyMovement>();
            _enemyAnimator = GetComponent<EnemyAnimator>();

            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        private void Start()
        {
            SubscribeMovementEvents();
        }

        private void OnDestroy()
        {
            UnsubscribeMovementEvents();
        }

        private void FixedUpdate()
        {
            _aiActor.Update();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<PlayerComponent>(out var player))
            {
                HasEnemy = true;
                Target = player;
                _enemyAnimator.SetHasEnemy(HasEnemy);
            }
        }

        public void Move(Vector3 direction)
        {
            _movementComponent.Move(direction);
        }

        private void FlipView(MovementDirection direction)
        {
            if (_spriteRenderer != null)
            {
                switch (direction)
                {
                    case MovementDirection.Left:
                        _spriteRenderer.flipX = false;
                        break;

                    case MovementDirection.Right:
                        _spriteRenderer.flipX = true;
                        break;
                }
            }
        }

        private void SubscribeMovementEvents()
        {
            _movementComponent.Moved += FlipView;
            _movementComponent.Moved += _enemyAnimator.SwitchMovementAnimation;
            _movementComponent.GroundStateChanged += _enemyAnimator.SetGrounded;
        }

        private void UnsubscribeMovementEvents()
        {
            _movementComponent.Moved -= FlipView;
            _movementComponent.Moved -= _enemyAnimator.SwitchMovementAnimation;
            _movementComponent.GroundStateChanged -= _enemyAnimator.SetGrounded;
        }
    }
}
