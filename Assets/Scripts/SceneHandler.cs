using UnityEngine.SceneManagement;

public static class SceneHandler
{
    public static void RestartLevel()
    {
        var currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public static void StartLevel(string nextLevelName)
    {
        SceneManager.LoadScene(nextLevelName);
    }
}