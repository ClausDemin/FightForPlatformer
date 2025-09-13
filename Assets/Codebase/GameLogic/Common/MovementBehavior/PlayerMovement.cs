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
        private IMovementService _movementService;
        private IJumpService _jumpService;

        private GroundChecker _groundChecker;
        private Rigidbody2D _rigidbody;

        private float _movementSpeed;
        private float _jumpForce;
        private bool _isGrounded;

        [Inject]
        public void Construct(IMovementService movementService, IJumpService jumpService, GroundChecker groundChecker, StaticDataProvider playerStaticData)
        {
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
        }

        public void Move(Vector3 direction)
        {
            _movementService.Move(_rigidbody, direction, _movementSpeed);

            Moved?.Invoke(GetDirection(direction));
        }

        public bool TryJump()
        {
            if (_isGrounded)
            {
                _jumpService.Jump(_rigidbody, _jumpForce);

                Jumped?.Invoke();

                return true;
            }

            return false;
        }

        private MovementDirection GetDirection(Vector3 direction)
        {

            if (direction == Vector3.right)
            {
                return MovementDirection.Right;
            }
            else if (direction == Vector3.left)
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
