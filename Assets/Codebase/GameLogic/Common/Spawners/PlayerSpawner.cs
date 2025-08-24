using Assets.Codebase.GameLogic.Common.CameraControls;
using Assets.Codebase.GameLogic.Services;
using UnityEngine;
using Zenject;

namespace Assets.Codebase.GameLogic.Common.Spawners
{
    public class PlayerSpawner: MonoBehaviour
    {
        [SerializeField] private CameraFollow _camera;

        private ActorsFactory _actorsFactory;

        [Inject]
        public void Construct(ActorsFactory actorsFactory) 
        { 
            _actorsFactory = actorsFactory;
        }

        private void Awake()
        {
           _camera.Init(_actorsFactory.CreatePlayer(transform.position));
        }
    }
}
