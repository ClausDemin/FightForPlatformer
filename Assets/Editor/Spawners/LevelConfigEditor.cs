using Assets.Codebase.GameLogic.Common.Spawners;
using Assets.Codebase.GameLogic.Configs;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


[CustomEditor(typeof(LevelConfig))]
public class LevelConfigEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var levelData = (LevelConfig)target;

        if (GUILayout.Button("Collect"))
        {
            levelData.SpawnersPosition = FindObjectsOfType<EnemySpawner>()
                .Select(x => x.transform.position)
                .ToArray();

            levelData.SceneName = SceneManager.GetActiveScene().name;
        }

        EditorUtility.SetDirty(target);
    }
}
