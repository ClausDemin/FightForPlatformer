using Assets.Codebase.GameLogic.Common.Actor.Player;
using Assets.Codebase.GameLogic.Common.AttackBehavior;
using Assets.Codebase.GameLogic.Common.AttackBehavior.Interface;
using Assets.Codebase.GameLogic.Common.HealthBehavior;
using Assets.Codebase.GameLogic.Infrastructure.Configs;
using Assets.Codebase.GameLogic.Services.ResourcesLoading;
using Assets.HealthBarPractice.Codebase.Common.HealthBehavior.View.Interface;
using UnityEngine;
using UnityEngine.TextCore.Text;
using Zenject;

namespace Assets.Codebase.GameLogic.Infrastructure.Factories
{
    public class PlayerFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IDamageService _damageService;
        private readonly PlayerConfig _playerConfig;

        public PlayerFactory(IInstantiator instantiator, IDamageService damageService, StaticDataProvider staticDataProvider)
        {
            _instantiator = instantiator;
            _damageService = damageService;
            _playerConfig = staticDataProvider.PlayerConfig;
        }

        public PlayerComponent CreatePlayer(Vector3 position)
        {
            PlayerComponent player = _instantiator.InstantiatePrefabForComponent<PlayerComponent>(_playerConfig.PlayerPrefab, position, Quaternion.identity, null);

            player.GetComponent<HealthComponent>().Init(new HealthData(_playerConfig.MaxHealth));

            player.GetComponent<AttackComponent>().Init(_damageService, new AttackData(_playerConfig.Damage, _playerConfig.AttackRadius, _playerConfig.Cooldown));

            return player;
        }
    }
}
