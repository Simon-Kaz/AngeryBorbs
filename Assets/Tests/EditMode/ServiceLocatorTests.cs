using System;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ServiceLocatorTests
{
    private Scene _testScene;

    [SetUp]
    public void SetUp()
    {
        _testScene = TestSceneProvider.CreateScene();
        EditorSceneManager.OpenScene(_testScene.path, OpenSceneMode.Single);
    }

    [TearDown]
    public void TearDown()
    {
        EditorSceneManager.CloseScene(_testScene, true);
    }

    [OneTimeTearDown]
    public void TearDownAfterAll()
    {
        TestSceneProvider.DeleteAllTestScenes();
    }

    [Test]
    public void ServiceLocator_WithValidTag_WithValidComponent_IsSuccessful()
    {
        var testGO = new GameObject {tag = UnityTag.EnemyManager.Tag()}
            .AddComponent<EnemyManager>();

        ServiceLocator.LocateComponent<EnemyManager>(UnityTag.EnemyManager);
    }

    [Test]
    public void ServiceLocator_WithValidTag_WithoutValidComponent_ThrowsException()
    {
        var testGO = new GameObject {tag = UnityTag.EnemyManager.Tag()};

        Assert.Throws<NullReferenceException>(() =>
            ServiceLocator.LocateComponent<EnemyManager>(UnityTag.EnemyManager));
    }

    [Test]
    public void ServiceLocator_WithoutValidTag_WithoutValidComponent_ThrowsException()
    {
        var testGO = new GameObject();

        Assert.Throws<NullReferenceException>(() =>
            ServiceLocator.LocateComponent<EnemyManager>(UnityTag.EnemyManager));
    }
}