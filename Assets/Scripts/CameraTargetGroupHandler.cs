using Cinemachine;
using UnityEngine;

public class CameraTargetGroupHandler
{
    private readonly EnemyManager _enemyManager;
    private readonly Transform _playerPosition;
    private readonly CinemachineTargetGroup _targetGroup;

    public CameraTargetGroupHandler(EnemyManager enemyManager,
                                    Transform playerPosition,
                                    CinemachineTargetGroup targetGroup)
    {
        _enemyManager = enemyManager;
        _playerPosition = playerPosition;
        _targetGroup = targetGroup;
    }

    public void UpdateTargetGroup()
    {
        if (_targetGroup.m_Targets.Length != 0) ClearTargetGroup();

        _targetGroup.AddMember(_playerPosition, 1f, 2f);

        var enemies = _enemyManager.Enemies;
        foreach (var enemy in enemies)
        {
            _targetGroup.AddMember(enemy.transform, 1f, 0f);
        }
    }

    private void ClearTargetGroup()
    {
        foreach (var element in _targetGroup.m_Targets)
        {
            _targetGroup.RemoveMember(element.target);
        }
    }
}