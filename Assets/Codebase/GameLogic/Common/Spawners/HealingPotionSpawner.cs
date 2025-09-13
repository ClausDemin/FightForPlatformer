using Assets.Codebase.GameLogic.Infrastructure.Configs;
using Assets.Codebase.GameLogic.Services.ResourcesLoading;
using UnityEngine;
using Zenject;

namespace Assets.Codebase.GameLogic.Common.Spawners
{
    public class HealingPotionSpawner: MonoBehaviour
    {
        private HealingPotionConfig _config;

        [Inject]
        public void Construct(StaticDataProvider dataProvider) 
        { 
            _config = dataProvider.HealingPotionConfig;
        }

        private void Awake()
        {
            Spawn();
        }

        private void Spawn() 
        {
            float chance = Random.value;

            if (chance > _config.SpawnChance) 
            { 
                HealingPotion instance = Instantiate(_config.Prefab, transform.position, Quaternion.identity, null);
                instance.Construct(_config.HealingAmount);
            }
        }
    }
}
