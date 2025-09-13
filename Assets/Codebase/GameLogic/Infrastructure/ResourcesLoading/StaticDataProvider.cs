using Assets.Codebase.GameLogic.Infrastructure.Configs;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Services.ResourcesLoading
{
    public class StaticDataProvider
    {
        private const string PlayerConfigPath = "Player/Player";
        private const string EnemyConfigPath = "Enemies/Bandit/BanditConfig";
        private const string HealingPotionPath = "Goods/Potion/HealingPotion";

        public StaticDataProvider() 
        {
            PlayerConfig = Resources.Load<PlayerConfig>(PlayerConfigPath);
            EnemyConfig = Resources.Load<EnemyConfig>(EnemyConfigPath);
            HealingPotionConfig = Resources.Load<HealingPotionConfig>(HealingPotionPath);
        }

        public PlayerConfig PlayerConfig { get; private set; }
        public EnemyConfig EnemyConfig { get; private set; }
        public HealingPotionConfig HealingPotionConfig { get; private set; }
    }
}
