using Assets.Codebase.GameLogic.Common.Actor.Enemy;
using Assets.Codebase.GameLogic.Common.AI;
using Assets.Codebase.GameLogic.Common.AI.Nodes.Implementation;
using Assets.Codebase.GameLogic.Common.Ground;
using Assets.Codebase.GameLogic.Common.MovementBehavior;
using Assets.Codebase.GameLogic.Infrastructure.Configs;
using Assets.Codebase.GameLogic.Services.ResourcesLoading;
using UnityEngine;
using Zenject;

namespace Assets.Codebase.GameLogic.Infrastructure.Factories
{
    public class EnemyFactory
    {

        private readonly EnemyConfig _enemyConfig; 
        private readonly IInstantiator _instantiator;

        private GroundChecker _groundChecker;
        private MovementCalculator _movementCalculator;
        private RotationService _rotationService;

        public EnemyFactory(IInstantiator instantiator, StaticDataProvider staticDataProvider,
                             GroundChecker groundChecker, MovementCalculator calculator, RotationService rotationService)
        {
            _enemyConfig = staticDataProvider.EnemyConfig;
            _instantiator = instantiator;
            _groundChecker = groundChecker;
            _movementCalculator = calculator;
            _rotationService = rotationService;
        }

        public EnemyComponent CreateEnemy(Vector3 position) 
        {
            EnemyComponent character = _instantiator.InstantiatePrefabForComponent<EnemyComponent>(_enemyConfig.Prefab, position, Quaternion.identity, null);

            character.Init(CreateBanditBehaviorTree(character, _groundChecker, _movementCalculator), _rotationService);

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
