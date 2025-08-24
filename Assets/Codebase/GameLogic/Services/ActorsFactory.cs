using Assets.Codebase.GameLogic.Common.Actor.Enemy;
using Assets.Codebase.GameLogic.Common.Actor.Player;
using Assets.Codebase.GameLogic.Common.AI;
using Assets.Codebase.GameLogic.Common.AI.Nodes.Implementation;
using Assets.Codebase.GameLogic.Common.Ground;
using Assets.Codebase.GameLogic.Common.MovementBehavior;
using Assets.Codebase.GameLogic.Configs;
using Assets.Codebase.GameLogic.Services.ResourcesLoading;
using UnityEngine;
using Zenject;

namespace Assets.Codebase.GameLogic.Services
{
    public class ActorsFactory
    {
        private readonly PlayerConfig _playerConfig;
        private readonly EnemyConfig _enemyConfig;
        
        private readonly IInstantiator _instantiator;

        private GroundChecker _groundChecker;
        private MovementCalculator _movementCalculator;

        public ActorsFactory(IInstantiator instantiator, StaticDataProvider staticDataProvider, GroundChecker groundChecker, MovementCalculator calculator)
        {
            _playerConfig = staticDataProvider.PlayerConfig;
            _enemyConfig = staticDataProvider.EnemyConfig;
            _instantiator = instantiator;
            _groundChecker = groundChecker;
            _movementCalculator = calculator;
        }

        public PlayerComponent CreatePlayer(Vector3 position)
        {
            return _instantiator.InstantiatePrefabForComponent<PlayerComponent>(_playerConfig.PlayerPrefab, position, Quaternion.identity, null);
        }

        public EnemyComponent CreateEnemy(Vector3 position) 
        {
            EnemyComponent character = _instantiator.InstantiatePrefabForComponent<EnemyComponent>(_enemyConfig.Prefab, position, Quaternion.identity, null);

            character.Init(CreateBanditBehaviorTree(character, _groundChecker, _movementCalculator));

            return character;

        }

        private BehaviorTree CreateBanditBehaviorTree(EnemyComponent character, GroundChecker groundChecker, MovementCalculator calculator)
        {
            Move moveBehavior = new Move(character, groundChecker, calculator);

            return new BehaviorTree
                (
                    new Selector
                    (
                        new HasEnemy
                        (
                            new MoveToEnemy(character, moveBehavior),
                            character
                        ),

                        new Patrol(character, moveBehavior)
                    )
                );
        }
    }
}
