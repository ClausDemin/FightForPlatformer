using Assets.Codebase.GameLogic.Common.Actor.Enemy;
using Assets.Codebase.GameLogic.Common.AI;
using Assets.Codebase.GameLogic.Common.AI.Nodes.Core;
using Assets.Codebase.GameLogic.Common.AI.Nodes.Implementation;
using Assets.Codebase.GameLogic.Common.AttackBehavior;
using Assets.Codebase.GameLogic.Common.AttackBehavior.Interface;
using Assets.Codebase.GameLogic.Common.Ground;
using Assets.Codebase.GameLogic.Common.HealthBehavior;
using Assets.Codebase.GameLogic.Common.MovementBehavior;
using Assets.Codebase.GameLogic.Infrastructure.Configs;
using Assets.Codebase.GameLogic.Services.ResourcesLoading;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

namespace Assets.Codebase.GameLogic.Infrastructure.Factories
{
    public class EnemyFactory
    {

        private readonly IInstantiator _instantiator;
        private readonly IDamageService _damageService;
        private readonly EnemyConfig _enemyConfig; 

        private GroundChecker _groundChecker;
        private MovementCalculator _movementCalculator;
        private RotationService _rotationService;

        public EnemyFactory(IInstantiator instantiator, IDamageService damageService, StaticDataProvider staticDataProvider, 
                             GroundChecker groundChecker, MovementCalculator calculator, RotationService rotationService)
        {
            _instantiator = instantiator;
            _damageService = damageService;
            _enemyConfig = staticDataProvider.EnemyConfig;
            _groundChecker = groundChecker;
            _movementCalculator = calculator;
            _rotationService = rotationService;
        }

        public EnemyComponent CreateEnemy(Vector3 position) 
        {
            EnemyComponent character = _instantiator.InstantiatePrefabForComponent<EnemyComponent>(_enemyConfig.Prefab, position, Quaternion.identity, null);

            character.Init(CreateBanditBehaviorTree(character, _groundChecker, _movementCalculator), _rotationService);

            character.GetComponent<HealthComponent>().Init(new HealthData(_enemyConfig.MaxHealth));
            character.GetComponent<AttackComponent>().Init(_damageService, new AttackData(_enemyConfig.Damage, _enemyConfig.AttackRadius, _enemyConfig.Cooldown));

            return character;

        }

        private BehaviorTree CreateBanditBehaviorTree(EnemyComponent character, GroundChecker groundChecker, MovementCalculator calculator)
        {
            Move moveBehavior = new Move(character, groundChecker, calculator);
            HasEnemy hasEnemy = new HasEnemy(new Sequence(new MoveToEnemy(character, moveBehavior), new CanAttack(new Attack(character), character)), character);
            Sequence patrolBehavior = new Sequence(new ReturnToSpawnPoint(character, moveBehavior), new Patrol(character, moveBehavior));
            CanPatrol canPatrol = new CanPatrol(patrolBehavior, character);

            return new BehaviorTree
                (
                    new Selector
                    (
                        hasEnemy,
                        canPatrol
                    )
                );
        }
    }
}
