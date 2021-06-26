using System;
using System.IO;
using NUnit.Framework;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ServiceLocatorTests
{
    private string _sceneName;
    private Scene _testScene;
    private string _scenePath;

    [SetUp]
    public void SetUp()
    {
        _sceneName = "ServiceLocatorTestScene" + GUID.Generate();
        _testScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        _scenePath = $"Assets/Tests/EditMode/TestScenes/{_sceneName}.unity";
        EditorSceneManager.SaveScene(_testScene, _scenePath);
        EditorSceneManager.OpenScene(_scenePath, OpenSceneMode.Single);
    }

    [TearDown]
    public void TearDown()
    {
        EditorSceneManager.CloseScene(_testScene,true);
    }

    [OneTimeTearDown]
    public void TearDownAfterAll()
    {
        // Remove contents of the TestScenes directory
        if (Directory.Exists("Assets/Tests/EditMode/TestScenes"))
            Directory.Delete("Assets/Tests/EditMode/TestScenes", true);
        Directory.CreateDirectory("Assets/Tests/EditMode/TestScenes");
    }

    [Test]
    public void ServiceLocator_WithValidTag_WithValidComponent_IsSuccessful()
    {
        var testGO = new GameObject {tag = "EnemyManager"}
            .AddComponent<EnemyManager>();

        ServiceLocator.LocateComponent<EnemyManager>(UnityTag.EnemyManager);
    }

    [Test]
    public void ServiceLocator_WithValidTag_WithoutValidComponent_ThrowsException()
    {
        var testGO = new GameObject {tag = "EnemyManager"};

        Assert.Throws<NullReferenceException>( () => ServiceLocator.LocateComponent<EnemyManager>(UnityTag.EnemyManager));
    }

    [Test]
    public void ServiceLocator_WithoutValidTag_WithoutValidComponent_ThrowsException()
    {
        var testGO = new GameObject();

        Assert.Throws<NullReferenceException>( () => ServiceLocator.LocateComponent<EnemyManager>(UnityTag.EnemyManager));
    }


}
