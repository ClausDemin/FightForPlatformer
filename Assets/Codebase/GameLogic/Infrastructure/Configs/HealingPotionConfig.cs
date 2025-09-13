using UnityEngine;

namespace Assets.Codebase.GameLogic.Infrastructure.Configs
{
    [CreateAssetMenu(menuName = "Configs/Potion/HealingPotion", fileName = "HealingPotion")]
    public class HealingPotionConfig: ScriptableObject
    {
        [SerializeField][Range(0, 1)] private float _spawnChance;

        [field: SerializeField] public int HealingAmount { get; private set; }
        [field: SerializeField] public HealingPotion Prefab { get; private set; }
        
        public float SpawnChance => _spawnChance;
    }
}
