using Assets.Codebase.GameLogic.Infrastructure.Configs;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Services.ResourcesLoading
{
    public class StaticDataProvider
    {
        private const string PlayerConfigPath = "Player/Player";
        private const string EnemyConfigPath = "Enemies/Bandit/BanditConfig";
        private const string HealingPotionPath = "Goods/Potion/HealingPotion";
        private const string VampirismConfigPath = "Abilities/Vampirism/VampirismConfig";

        public StaticDataProvider() 
        {
            PlayerConfig = Resources.Load<PlayerConfig>(PlayerConfigPath);
            EnemyConfig = Resources.Load<EnemyConfig>(EnemyConfigPath);
            HealingPotionConfig = Resources.Load<HealingPotionConfig>(HealingPotionPath);
            VampirismConfig = Resources.Load<VampirismConfig>(VampirismConfigPath);
        }

        public PlayerConfig PlayerConfig { get; private set; }
        public EnemyConfig EnemyConfig { get; private set; }
        public HealingPotionConfig HealingPotionConfig { get; private set; }
        public VampirismConfig VampirismConfig { get; private set; }
    }
}
