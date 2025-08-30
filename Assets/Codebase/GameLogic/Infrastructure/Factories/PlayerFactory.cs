using Assets.Codebase.GameLogic.Common.Actor.Player;
using Assets.Codebase.GameLogic.Infrastructure.Configs;
using Assets.Codebase.GameLogic.Services.ResourcesLoading;
using UnityEngine;
using Zenject;

namespace Assets.Codebase.GameLogic.Infrastructure.Factories
{
    public class PlayerFactory
    {
        private readonly PlayerConfig _playerConfig;
        private readonly IInstantiator _instantiator;

        public PlayerFactory(StaticDataProvider staticDataProvider, IInstantiator instantiator)
        {
            _playerConfig = staticDataProvider.PlayerConfig;
            _instantiator = instantiator;
        }

        public PlayerComponent CreatePlayer(Vector3 position)
        {
            return _instantiator.InstantiatePrefabForComponent<PlayerComponent>(_playerConfig.PlayerPrefab, position, Quaternion.identity, null);
        }
    }
}
