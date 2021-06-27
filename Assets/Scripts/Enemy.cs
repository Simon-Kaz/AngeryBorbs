using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject cloudParticlePrefab;

    public delegate void EnemyHandler(Enemy enemy);
    public static event EnemyHandler OnEnemyKilled;
    public static event EnemyHandler OnEnemySpawned;

    private void Awake()
    {
        OnEnemySpawned?.Invoke(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var bird = collision.collider.GetComponent<Bird>();
        if (bird != null)
        {
            Instantiate(cloudParticlePrefab, transform.position, Quaternion.identity);
            OnEnemyKilled?.Invoke(this);
            Destroy(gameObject);
            return;
        }

        var enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null) return;

        if (collision.contacts[0].normal.y < -0.5)
        {
            Instantiate(cloudParticlePrefab, transform.position, Quaternion.identity);
            OnEnemyKilled?.Invoke(this);
            Destroy(gameObject);
        }
    }
}