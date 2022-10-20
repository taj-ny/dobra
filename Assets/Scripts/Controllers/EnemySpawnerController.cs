using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public sealed class EnemySpawnerController : MonoBehaviour
{
    private List<GameObject> _enemies;

    void Start()
    {
        _enemies = new();
    }

    private IEnumerator CoSpawnEnemy(GameObject enemyTemplate, float interval, Func<bool> shouldContinue)
    {
        yield return new WaitForSeconds(interval / 1000);

        _ = CreateEnemy(enemyTemplate, new(Random.Range(-5f, 5f), Random.Range(-8f, 8f)));

        if (shouldContinue())
            StartCoroutine(CoSpawnEnemy(enemyTemplate, interval, shouldContinue));
    }

    public void QueueEnemySpawn(GameObject enemyTemplate, int count, float interval)
    {
        var currentCount = 0; 
        StartCoroutine(CoSpawnEnemy(enemyTemplate, interval, () =>
        {
            currentCount++;
            return currentCount >= count;
        }));
    }

    public void DestroyEnemy(GameObject enemy, Action<IReadOnlyCollection<GameObject>> onRemovedCallback)
    {
        _enemies.Remove(enemy);
        Destroy(enemy);

        onRemovedCallback(_enemies);
    }

    private GameObject CreateEnemy(GameObject enemyTemplate, Vector2 position)
    {
        var clone = Instantiate(enemyTemplate, new(position.x, position.y), Quaternion.identity);
        _enemies.Add(clone);

        return clone;
    }
}
