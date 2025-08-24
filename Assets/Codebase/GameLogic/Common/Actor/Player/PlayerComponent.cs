using Assets.Codebase.GameLogic.Common.MovementBehavior;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Common.Actor.Player
{
    [RequireComponent(typeof(PlayerMovement), typeof(PlayerAnimator))]
    public class PlayerComponent: MonoBehaviour
    {
        private SpriteRenderer _playerView;
        private PlayerMovement _playerMovement;
        private PlayerAnimator _playerAnimator;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _playerAnimator = GetComponent<PlayerAnimator>();
        }

        private void Start()
        {
            _playerView = GetComponentInChildren<SpriteRenderer>();
            SubscribeMovementEvents();

        }

        private void OnDestroy()
        {
            UnsubscribeMovementEvents();
        }

        private void FlipView(MovementDirection direction) 
        {
            if (_playerView != null) 
            {
                switch (direction)
                {
                    case MovementDirection.Left:
                        _playerView.flipX = true;
                        break;

                    case MovementDirection.Right:
                        _playerView.flipX = false;
                        break;
                }
            }
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
