using Assets.Codebase.GameLogic.Services;
using UnityEngine;
using Zenject;

namespace Assets.Codebase.GameLogic.Common.Spawners
{
    public class EnemySpawner: MonoBehaviour
    {
        private ActorsFactory _actorsFactory;

        [Inject]
        public void Construct(ActorsFactory actorsFactory) 
        { 
            _actorsFactory = actorsFactory;
        }

        public void Awake() 
        {
            _actorsFactory.CreateEnemy(transform.position);
        }
    }
}
