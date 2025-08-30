using Assets.Codebase.GameLogic.Common.CameraControls;
using Assets.Codebase.GameLogic.Infrastructure.Factories;
using UnityEngine;
using Zenject;

namespace Assets.Codebase.GameLogic.Common.Spawners
{
    public class PlayerSpawner: MonoBehaviour
    {
        [SerializeField] private PlayerFollower _camera;

        private PlayerFactory _playerFactory;

        [Inject]
        public void Construct(PlayerFactory actorsFactory) 
        { 
            _playerFactory = actorsFactory;
        }

        private void Awake()
        {
           _camera.Init(_playerFactory.CreatePlayer(transform.position));
        }
    }
}
