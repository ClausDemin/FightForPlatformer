using UnityEngine;

namespace Assets.Codebase.GameLogic.Infrastructure.Configs
{
    [CreateAssetMenu(menuName = "Configs/Ability/Vampirism", fileName = "Vampirism")]
    public class VampirismConfig: ScriptableObject
    {
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float Radius { get; private set; }
        [field: SerializeField] public float Duration { get; private set; }
        [field: SerializeField] public float Cooldown { get; private set; }
    }
}
