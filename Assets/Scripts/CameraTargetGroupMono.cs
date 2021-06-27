using System.ComponentModel;
using Cinemachine;
using UnityEngine;

public class CameraTargetGroupMono : MonoBehaviour
{
    void Start()
    {
        var enemyManager = ServiceLocator
            .LocateComponent<EnemyManager>(UnityTag.EnemyManager);
        var playerPosition = ServiceLocator
            .LocateComponent<Bird>(UnityTag.PlayerCharacter)
            .transform;
        var targetGroup = GetComponent<CinemachineTargetGroup>();

        var handler = new CameraTargetGroupHandler(enemyManager, playerPosition, targetGroup);

        handler.UpdateTargetGroup();
    }
}