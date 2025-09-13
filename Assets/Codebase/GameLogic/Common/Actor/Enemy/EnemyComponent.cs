using Assets.Codebase.GameLogic.Common.Actor.Enemy.Animation;
using Assets.Codebase.GameLogic.Common.Actor.Player;
using Assets.Codebase.GameLogic.Common.Actor.Player.Animation;
using Assets.Codebase.GameLogic.Common.AI;
using Assets.Codebase.GameLogic.Common.AttackBehavior;
using Assets.Codebase.GameLogic.Common.HealthBehavior;
using Assets.Codebase.GameLogic.Common.MovementBehavior;
using Assets.Codebase.GameLogic.Common.MovementBehavior.Enum;
using System.Linq;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.Actor.Enemy
{
    [RequireComponent(typeof(EnemyAnimator), typeof(EnemyMovement), typeof(CollisionChecker))]
    [RequireComponent(typeof(HealthComponent), typeof(AttackComponent), typeof(Rigidbody2D))]
    public class EnemyComponent : MonoBehaviour
    {
        [SerializeField] private AnimationEventsListener _animationEvents;

        private RotationService _rotationService;
        private EnemyMovement _movementComponent;
        private EnemyAnimator _enemyAnimator;
        private CollisionChecker _collisionChecker;
        private HealthComponent _health;
        private AttackComponent _attack;
        private Rigidbody2D _body;
        private BehaviorTree _aiActor;

        public void Init(BehaviorTree aiActor, RotationService rotationService)
        {
            _aiActor = aiActor;
            _rotationService = rotationService;
        }

        public bool HasEnemy => Target != null;
        public PlayerComponent Target { get; private set; }

        private void Awake()
        {
            _movementComponent = GetComponent<EnemyMovement>();
            _enemyAnimator = GetComponent<EnemyAnimator>();
            _collisionChecker = GetComponent<CollisionChecker>();
            _health = GetComponent<HealthComponent>();
            _attack = GetComponent<AttackComponent>();
            _body = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            SubscribeMovementEvents();
            SubscribeHealthEvents();
            SubscribeAttackEvents();

            _collisionChecker.TriggerEntered += SetEnemy;
        }

        private void OnDestroy()
        {
            UnsubscribeMovementEvents();
            UnsubscribeHealthEvents();
            UnsubscribeAttackEvents();

            _collisionChecker.TriggerExited -= SetEnemy;
        }

        private void FixedUpdate()
        {
            _aiActor?.Update();
        }

        private void SetEnemy(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<PlayerComponent>(out var player))
            {
                Target = player;
                Target.Death += OnTargetDeath;
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

        private void SubscribeHealthEvents()
        {
            _health.DamageTaken += _enemyAnimator.PlayHitAnimation;
            _health.Death += _enemyAnimator.PlayDeathAnimation;
            _health.Death += OnDeath;
        }

        private void UnsubscribeHealthEvents()
        {
            _health.DamageTaken -= _enemyAnimator.PlayHitAnimation;
            _health.Death -= _enemyAnimator.PlayDeathAnimation;
            _health.Death -= OnDeath;
        }

        private void SubscribeAttackEvents()
        {
            _attack.Happened += _enemyAnimator.PlayAttackAnimation;
            _animationEvents.Attack += _attack.ApplyDamage;
            _animationEvents.AttackEnded += _attack.RaiseCooldown;
        }

        private void UnsubscribeAttackEvents()
        {
            _attack.Happened -= _enemyAnimator.PlayAttackAnimation;
            _animationEvents.Attack -= _attack.ApplyDamage;
            _animationEvents.AttackEnded -= _attack.RaiseCooldown;
        }

        private void OnDeath()
        {
            UnsubscribeTargetDeathEvent();
            DisableCollisions();

            this.enabled = false;
            _aiActor = null;
        }

        private void DisableCollisions()
        {
            _body.bodyType = RigidbodyType2D.Kinematic;
            Collider2D[] colliders = new Collider2D[5];
            _body.GetAttachedColliders(colliders);

            foreach (Collider2D collider in colliders.Where(x => x != null))
            {
                collider.enabled = false;
            }
        }

        private void UnsubscribeTargetDeathEvent()
        {
            if (Target != null)
            {
                Target.Death -= OnTargetDeath;
            }
        }

        private void OnTargetDeath()
        {
            Target = null;
            _enemyAnimator.SetHasEnemy(false);
        }
    }
}
