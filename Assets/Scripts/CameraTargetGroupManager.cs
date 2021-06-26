using Cinemachine;
using UnityEngine;

public class CameraTargetGroupManager : MonoBehaviour
{
    private EnemyManager _enemyManager;
    private Bird _playerBird;
    private CinemachineTargetGroup _targetGroup;
    private void Start()
    {
        _enemyManager = ServiceLocator.LocateComponent<EnemyManager>(UnityTag.EnemyManager);
        _playerBird = ServiceLocator.LocateComponent<Bird>(UnityTag.PlayerCharacter);
        _targetGroup = GetComponent<CinemachineTargetGroup>();
        UpdateTargetGroup();
    }

    private void UpdateTargetGroup()
    {
        if (_targetGroup.m_Targets.Length != 0) ClearTargetGroup();

        _targetGroup.AddMember(_playerBird.transform, 1f, 2f);

        var enemies = _enemyManager.Enemies;
        foreach(var enemy in enemies)
        {
            _targetGroup.AddMember(enemy.transform,1f, 0f);
        }
    }

    private void ClearTargetGroup()
    {
        foreach(var element in _targetGroup.m_Targets)
        {
            _targetGroup.RemoveMember(element.target);
        }
    }
}