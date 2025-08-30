using Assets.Codebase.GameLogic.Common.Actor.Enemy.Animation;
using Assets.Codebase.GameLogic.Common.Actor.Player;
using Assets.Codebase.GameLogic.Common.AI;
using Assets.Codebase.GameLogic.Common.MovementBehavior;
using Assets.Codebase.GameLogic.Common.MovementBehavior.Enum;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.Actor.Enemy
{
    [RequireComponent(typeof(EnemyAnimator), typeof(EnemyMovement))]
    public class EnemyComponent : MonoBehaviour
    {
        private RotationService _rotationService;
        private EnemyMovement _movementComponent;
        private EnemyAnimator _enemyAnimator;
        private CollisionChecker _collisionChecker;
        private BehaviorTree _aiActor;


        public void Init(BehaviorTree aiActor, RotationService rotationService) 
        {
            _aiActor = aiActor;
            _rotationService = rotationService;
        }

        public bool HasEnemy { get; private set; }
        public PlayerComponent Target { get; private set; }

        private void Awake()
        {
            _movementComponent = GetComponent<EnemyMovement>();
            _enemyAnimator = GetComponent<EnemyAnimator>();
            _collisionChecker = GetComponent<CollisionChecker>();
        }

        private void Start()
        {
            SubscribeMovementEvents();
            _collisionChecker.TriggerEntered += SetEnemy;
        }

        private void OnDestroy()
        {
            UnsubscribeMovementEvents();
        }

        private void FixedUpdate()
        {
            _aiActor.Update();
        }

        private void SetEnemy(Collider2D collision)
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
            _rotationService.RotateFaceToDirection(transform, direction);
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
