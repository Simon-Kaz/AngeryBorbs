using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager: MonoBehaviour
{
    public List<Enemy> Enemies { get; private set; }
    public static event Action OnAllEnemiesKilled;

    private void OnEnable()
    {
        Enemies = FindObjectsOfType<Enemy>().ToList();
    }

    private void Start()
    {
        Enemy.OnEnemyKilled += OnEnemyKilledHandler;
    }

    private void OnEnemyKilledHandler(Enemy enemy)
    {
        Debug.Log("Enemy destroyed \n");
        Debug.Log(enemy.name);
        Enemies.Remove(enemy);

        if (Enemies.Count == 0)
        {
            OnAllEnemiesKilled?.Invoke();
        }
    }
}