using Assets.Codebase.GameLogic.Common.Actor.Player;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Infrastructure.Configs
{
    [CreateAssetMenu(menuName = "Configs/Player", fileName = "PlayerConfig")]
    public class PlayerConfig: ScriptableObject
    {
        [field: SerializeField] public PlayerComponent PlayerPrefab { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float JumpForce { get; private set; }
    }
}
