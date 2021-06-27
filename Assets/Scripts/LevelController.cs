using UnityEngine;

public class LevelController : MonoBehaviour
{
    private static int _nextLevelIndex = 1;
    private static string GetNextLevelName => "Level" + _nextLevelIndex;

    private void OnEnable()
    {
        EnemyManager.OnAllEnemiesKilled += EndLevelHandler;
        Bird.OnBirdResetRequired += SceneHandler.RestartLevel;
    }

    private void EndLevelHandler()
    {
        Debug.Log("You killed all enemies", this);
        _nextLevelIndex++;
        var nextLevelName = GetNextLevelName;
        if (SceneHandler.IsLevelAvailable(nextLevelName))
        {
            SceneHandler.StartLevel(nextLevelName);
        }
        else
        {
            Debug.Log("Next level is not available");
        }
    }
}