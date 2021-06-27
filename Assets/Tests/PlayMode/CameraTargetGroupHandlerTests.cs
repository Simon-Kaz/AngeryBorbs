using System.Collections;
using Cinemachine;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CameraTargetGroupHandlerTests
{
    [UnityTest]
    public IEnumerator CameraTargetGroup_AddsEnemiesAndPlayerToTheTargetGroup()
    {
        // Arrange
        var enemy = new GameObject().AddComponent<Enemy>();
        var enemyManager = new GameObject().AddComponent<EnemyManager>();
        var playerPosition = new GameObject().AddComponent<Bird>().transform;
        var targetGroup = new GameObject().AddComponent<CinemachineTargetGroup>();
        yield return new WaitForEndOfFrame();

        var handler = new CameraTargetGroupHandler(enemyManager, playerPosition, targetGroup);

        // Act
        handler.UpdateTargetGroup();

        // Assert
        Assert.That(targetGroup.m_Targets.Length, Is.EqualTo(2));
    }

    [UnityTest]
    public IEnumerator CameraTargetGroup_GroupIsClearedBeforeUpdating()
    {
        // Arrange
        var enemyManager = new GameObject().AddComponent<EnemyManager>();
        var playerPosition = new GameObject().AddComponent<Bird>().transform;
        var targetGroup = new GameObject().AddComponent<CinemachineTargetGroup>();
        yield return new WaitForEndOfFrame();
        var handler = new CameraTargetGroupHandler(enemyManager, playerPosition, targetGroup);

        // Act
        handler.UpdateTargetGroup();
        Assert.That(targetGroup.m_Targets.Length, Is.EqualTo(1));

        // Assert
        var enemy = new GameObject().AddComponent<Enemy>();
        yield return new WaitForEndOfFrame();

        handler.UpdateTargetGroup();

        Assert.That(targetGroup.m_Targets.Length, Is.EqualTo(2));
    }
}