using Assets.Codebase.GameLogic.Common.Ground;
using Assets.Codebase.GameLogic.Common.JumpBehavior.Interface;
using Assets.Codebase.GameLogic.Common.MovementBehavior.Enum;
using Assets.Codebase.GameLogic.Common.MovementBehavior.Interface;
using Assets.Codebase.GameLogic.Infrastructure.Inputs.Interface;
using Assets.Codebase.GameLogic.Services.ResourcesLoading;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Codebase.GameLogic.Common.MovementBehavior
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private IInputService _inputService;
        private IMovementService _movementService;
        private IJumpService _jumpService;

        private GroundChecker _groundChecker;
        private Rigidbody2D _rigidbody;

        private float _movementSpeed;
        private float _jumpForce;
        private bool _isGrounded;

        [Inject]
        public void Construct(IInputService inputService, IMovementService movementService, IJumpService jumpService,
                              GroundChecker groundChecker, StaticDataProvider playerStaticData)
        {
            _inputService = inputService;
            _movementService = movementService;
            _groundChecker = groundChecker;
            _jumpService = jumpService;

            _movementSpeed = playerStaticData.PlayerConfig.Speed;
            _jumpForce = playerStaticData.PlayerConfig.JumpForce;
        }

        public event Action<MovementDirection> Moved;
        public event Action Jumped;
        public event Action<bool> GroundStateChanged;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            CheckGround();
            Move(_rigidbody, _movementSpeed);
            TryJump(_rigidbody, _jumpForce);
        }

        private void Move(Rigidbody2D actor, float speed)
        {
            float input = _inputService.Horizontal;

            Vector3 direction = (Vector3.right * input).normalized;

            if (input != 0)
            {
                _movementService.Move(actor, direction, speed);
            }

            Moved?.Invoke(GetDirection(input));
        }

        private bool TryJump(Rigidbody2D actor, float jumpForce)
        {
            if (_inputService.IsJumpButtonDown() && _isGrounded)
            {
                _jumpService.Jump(actor, jumpForce);

                Jumped?.Invoke();

                return true;
            }

            return false;
        }

        private MovementDirection GetDirection(float input)
        {

            if (input > 0)
            {
                return MovementDirection.Right;
            }
            else if (input < 0)
            {
                return MovementDirection.Left;
            }

            return MovementDirection.None;
        }

        private void CheckGround()
        {
            bool isGrounded = _groundChecker.CheckGround(transform.position);

            if (_isGrounded != isGrounded)
            {
                _isGrounded = isGrounded;
                GroundStateChanged?.Invoke(_isGrounded);
            }
        }
    }
}
