using Assets.Codebase.GameLogic.Configs;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Services.ResourcesLoading
{
    public class StaticDataProvider
    {
        private const string PlayerConfigPath = "Player/Player";
        private const string EnemyConfigPath = "Enemies/Bandit/BanditConfig";

        public StaticDataProvider() 
        {
            PlayerConfig = Resources.Load<PlayerConfig>(PlayerConfigPath);
            EnemyConfig = Resources.Load<EnemyConfig>(EnemyConfigPath);
        }

        public PlayerConfig PlayerConfig { get; private set; }
        public EnemyConfig EnemyConfig { get; private set; }
    }
}
