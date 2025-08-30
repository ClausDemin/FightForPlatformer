using Assets.Codebase.GameLogic.Common.Actor.Player.Animation;
using Assets.Codebase.GameLogic.Common.MovementBehavior;
using Assets.Codebase.GameLogic.Common.MovementBehavior.Enum;
using UnityEngine;
using Zenject;

namespace Assets.Codebase.GameLogic.Common.Actor.Player
{
    [RequireComponent(typeof(PlayerMovement), typeof(PlayerAnimator))]
    public class PlayerComponent : MonoBehaviour
    {
        private RotationService _rotationService;
        private PlayerAnimator _playerAnimator;
        private PlayerMovement _playerMovement;
        private InventoryComponent _inventoryComponent;
        private CollisionChecker _collisionChecker;


        [Inject]
        public void Construct(RotationService rotationService)
        {
            _rotationService = rotationService;
        }

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _playerAnimator = GetComponent<PlayerAnimator>();

            _inventoryComponent = GetComponent<InventoryComponent>();
            _collisionChecker = GetComponent<CollisionChecker>();
        }

        private void Start()
        {
            SubscribeMovementEvents();

            _collisionChecker.CollisionEntered += _inventoryComponent.HandleCollision;
        }

        private void OnDestroy()
        {
            UnsubscribeMovementEvents();
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
    }
}
