using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public sealed class EnemySpawnerController : MonoBehaviour
{
    [SerializeField] private CameraBoundsController _cameraBoundsController;

    private List<GameObject> _enemies;

    void Start()
    {
        _enemies = new();
    }

    private IEnumerator CoSpawnEnemy(GameObject enemyTemplate, float interval, Func<bool> shouldContinue)
    {
        yield return new WaitForSeconds(interval / 1000);

        var cameraRect = new Rect(_cameraBoundsController.TopLeft.x, _cameraBoundsController.TopLeft.y,
            _cameraBoundsController.TopRight.x - _cameraBoundsController.TopLeft.x,
            _cameraBoundsController.BottomLeft.y - _cameraBoundsController.TopLeft.y);
        var screenRect = new Rect(cameraRect.x - 10, cameraRect.y - 10, cameraRect.width + 20, cameraRect.height + 20);
        
        var x = Random.Range(screenRect.xMin, screenRect.xMax - cameraRect.width);
        var y = Random.Range(screenRect.yMin, screenRect.yMax - cameraRect.height);
        x = x > cameraRect.xMin ? x + cameraRect.width : x;
        y = y > cameraRect.yMin ? x + cameraRect.height : y;
         _= CreateEnemy(enemyTemplate, new(x, y));

         if (shouldContinue())
            StartCoroutine(CoSpawnEnemy(enemyTemplate, interval, shouldContinue));
    }

    public void QueueEnemySpawn(GameObject enemyTemplate, int count, float interval)
    {
        var currentCount = 0; 
        StartCoroutine(CoSpawnEnemy(enemyTemplate, interval, () =>
        {
            currentCount++;
            return count > currentCount;
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
