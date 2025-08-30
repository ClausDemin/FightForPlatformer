using Assets.Codebase.GameLogic.Infrastructure.Factories;
using UnityEngine;
using Zenject;

namespace Assets.Codebase.GameLogic.Common.Spawners
{
    public class EnemySpawner: MonoBehaviour
    {
        private EnemyFactory _actorsFactory;

        [Inject]
        public void Construct(EnemyFactory actorsFactory) 
        { 
            _actorsFactory = actorsFactory;
        }

        public void Awake() 
        {
            _actorsFactory.CreateEnemy(transform.position);
        }
    }
}
