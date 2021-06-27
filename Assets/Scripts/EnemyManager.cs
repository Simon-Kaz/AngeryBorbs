using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager: MonoBehaviour
{
    public HashSet<Enemy> Enemies { get; private set; }

    public static event Action OnAllEnemiesKilled;

    private void OnEnable()
    {
        Enemies = new HashSet<Enemy>(FindObjectsOfType<Enemy>());
    }

    private void Start()
    {
        Enemy.OnEnemySpawned += OnEnemySpawnedHandler;
        Enemy.OnEnemyKilled += OnEnemyKilledHandler;
    }

    private void OnEnemySpawnedHandler(Enemy enemy)
    {
        Debug.Log("New enemy added");
        Debug.Log(enemy.name);
        Enemies.Add(enemy);
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