using System;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public static class TestSceneProvider
{
    private const string TestScenePath = "Assets/Tests/EditMode/TestScenes";

    public static Scene CreateScene()
    {
        var sceneName = "EditTestScene" + GUID.Generate();
        var scenePath = $"{TestScenePath}/{sceneName}.unity";
        var testScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        return EditorSceneManager.SaveScene(testScene, scenePath)
            ? testScene
            : throw new Exception("Scene could not be created");
    }

    public static void DeleteAllTestScenes()
    {
        // Remove contents of the TestScenes directory
        if (Directory.Exists(TestScenePath))
            Directory.Delete(TestScenePath, true);

        Directory.CreateDirectory(TestScenePath);
    }
}