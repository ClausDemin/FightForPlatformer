using Assets.Codebase.GameLogic.Common.Actor.Enemy;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Configs
{
    [CreateAssetMenu(menuName = "Configs/Enemy", fileName = "EnemyConfig")]
    public class EnemyConfig: ScriptableObject
    {

        [field: SerializeField] public EnemyComponent Prefab { get; private set; }
        [field: SerializeField] public float MovementSpeed { get; private set; }
        [field: SerializeField] public float JumpHeight { get; private set; }
        [field: SerializeField] public float JumpDistance { get; private set; }
    }
}
