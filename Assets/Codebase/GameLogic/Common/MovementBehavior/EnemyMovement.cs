using Assets.Codebase.GameLogic.Common.Ground;
using Assets.Codebase.GameLogic.Common.MovementBehavior.Interface;
using Assets.Codebase.GameLogic.Services.ResourcesLoading;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Codebase.GameLogic.Common.MovementBehavior
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyMovement : MonoBehaviour
    {
        private IMovementService _movementService;
        private GroundChecker _groundChecker;
        private Rigidbody2D _rigidbody;

        private float _jumpHeight;
        private float _jumpDistance;
        private bool _isGrounded;

        [Inject]
        public void Construct(IMovementService movementService, GroundChecker groundChecker, StaticDataProvider staticDataProvider)
        {
            _movementService = movementService;
            _groundChecker = groundChecker;

            MovementSpeed = staticDataProvider.EnemyConfig.MovementSpeed;
            _jumpHeight = staticDataProvider.EnemyConfig.JumpHeight;
            _jumpDistance = staticDataProvider.EnemyConfig.JumpDistance;
        }

        public event Action<MovementDirection> Moved;
        public event Action<bool> GroundStateChanged;

        public float MovementSpeed { get; private set; }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Move(Vector3 direction)
        {
            _movementService.Move(_rigidbody, direction, MovementSpeed);
            Moved?.Invoke(GetMovementDirection(direction));
            CheckGround();
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

        private MovementDirection GetMovementDirection(Vector3 direction)
        {
            if (direction.x > 0)
            {
                return MovementDirection.Right;
            }
            else if (direction.x < 0)
            {
                return MovementDirection.Left;
            }

            return MovementDirection.None;
        }
    }
}
