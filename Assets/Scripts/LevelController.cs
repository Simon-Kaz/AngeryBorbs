using UnityEngine;

public class LevelController : MonoBehaviour
{
    private static int _nextLevelIndex = 1;
    private static string GetNextLevelName => "Level" + _nextLevelIndex;

    private void OnEnable()
    {
        EnemyManager.OnAllEnemiesKilled += EndLevelHandler;
    }

    private void EndLevelHandler()
    {
        Debug.Log("You killed all enemies", this);
        _nextLevelIndex++;
        SceneHandler.StartLevel(GetNextLevelName);
    }
}