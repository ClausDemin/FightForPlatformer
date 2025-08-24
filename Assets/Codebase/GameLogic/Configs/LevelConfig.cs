using UnityEngine;

namespace Assets.Codebase.GameLogic.Configs
{
    [CreateAssetMenu(menuName = "Configs/Level", fileName = "LevelData")]
    public class LevelConfig: ScriptableObject
    {
        public string SceneName;

        public Vector3[] SpawnersPosition;
    }
}
