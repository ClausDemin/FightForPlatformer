using Assets.Codebase.GameLogic.Common.Actor.Player.Animation;
using Assets.Codebase.GameLogic.Common.AttackBehavior;
using Assets.Codebase.GameLogic.Common.HealthBehavior;
using Assets.Codebase.GameLogic.Common.InventoryBehavior;
using Assets.Codebase.GameLogic.Common.MovementBehavior;
using Assets.Codebase.GameLogic.Common.MovementBehavior.Enum;
using Assets.Codebase.GameLogic.Infrastructure.Inputs.Interface;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Codebase.GameLogic.Common.Actor.Player
{
    [RequireComponent(typeof(PlayerMovement), typeof(PlayerAnimator), typeof(InventoryComponent))]
    [RequireComponent(typeof(HealthComponent), typeof(AttackComponent), typeof(CollisionChecker))]
    public class PlayerComponent : MonoBehaviour
    {
        [SerializeField] private AnimationEventsListener _animationEvents;

        private IInputService _inputService;
        private RotationService _rotationService;
        private PlayerAnimator _playerAnimator;
        private PlayerMovement _playerMovement;
        private HealthComponent _health;
        private AttackComponent _attack;
        private InventoryComponent _inventoryComponent;
        private CollisionChecker _collisionChecker;

        [Inject]
        public void Construct(IInputService inputService, RotationService rotationService)
        {
            _inputService = inputService;
            _rotationService = rotationService;
        }

        public event Action Death;

        public bool IsAlive => _health.IsAlive;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _playerAnimator = GetComponent<PlayerAnimator>();
            _health = GetComponent<HealthComponent>();
            _attack = GetComponent<AttackComponent>();
            _inventoryComponent = GetComponent<InventoryComponent>();
            _collisionChecker = GetComponent<CollisionChecker>();
        }

        private void Start()
        {
            SubscribeMovementEvents();

            _collisionChecker.CollisionEntered += _inventoryComponent.HandleCollision;

            SubscribeAttackEvents();

            SubscribeHealthEvents();
        }

        private void Update()
        {
            HandleAttackInput();
        }

        private void FixedUpdate()
        {
            HandleMovementInput();
            HandleJumpInput();
        }

        private void OnDestroy()
        {
            UnsubscribeMovementEvents();

            _collisionChecker.CollisionEntered -= _inventoryComponent.HandleCollision;

            UnsubscribeAttackEvents();

            UnsubscribeHealthEvents();
        }

        private void HandleMovementInput()
        {
            float input = _inputService.Horizontal;

            Vector3 direction = (Vector3.right * input).normalized;

            
            _playerMovement.Move(direction);
        }

        private void HandleJumpInput()
        {
            if (_inputService.IsJumpButtonDown())
            {
                _playerMovement.TryJump();
            }
        }

        private void HandleAttackInput()
        {
            if (_inputService.IsAttackButtonDown())
            {
                _attack.TryStart();
            }
        }

        private void FlipView(MovementDirection direction)
        {
            _rotationService.RotateFaceToDirection(transform, direction);
        }

        private void SubscribeMovementEvents()
        {
            _playerMovement.Moved += FlipView;
            _playerMovement.Moved += _playerAnimator.SwitchMovementAnimation;
            _playerMovement.GroundStateChanged += _playerAnimator.SetGroundedFlag;
            _playerMovement.Jumped += _playerAnimator.PlayJumpAnimation;
        }

        private void UnsubscribeMovementEvents()
        {
            _playerMovement.Moved -= FlipView;
            _playerMovement.Moved -= _playerAnimator.SwitchMovementAnimation;
            _playerMovement.GroundStateChanged -= _playerAnimator.SetGroundedFlag;
            _playerMovement.Jumped -= _playerAnimator.PlayJumpAnimation;
        }

        private void SubscribeHealthEvents()
        {
            _health.DamageTaken += _playerAnimator.PlayHitAnimation;
            _health.Death += _playerAnimator.PlayDeathAnimation;
            _health.Death += OnDeath;
        }

        private void UnsubscribeHealthEvents()
        {
            _health.DamageTaken -= _playerAnimator.PlayHitAnimation;
            _health.Death -= _playerAnimator.PlayDeathAnimation;
            _health.Death -= OnDeath;
        }

        private void SubscribeAttackEvents()
        {
            _attack.Happened += _playerAnimator.PlayAttackAnimation;
            _animationEvents.Attack += _attack.ApplyDamage;
            _animationEvents.AttackEnded += _attack.RaiseCooldown;
        }

        private void UnsubscribeAttackEvents()
        {
            _attack.Happened -= _playerAnimator.PlayAttackAnimation;
            _animationEvents.Attack -= _attack.ApplyDamage;
            _animationEvents.AttackEnded -= _attack.RaiseCooldown;
        }

        private void OnDeath()
        {
            this.enabled = false;
            Death?.Invoke();
        }
    }
}
