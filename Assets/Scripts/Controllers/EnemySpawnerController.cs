using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    private List<GameObject> _enemies;

    [SerializeField]
    private GameObject _enemy1;

    void Start()
    {
        _enemies = new();
    }

    void Update()
    {
        StartCoroutine(CoSpawnEnemy(_enemy1, 4000f));
    }

    private IEnumerator CoSpawnEnemy(GameObject enemyTemplate, float interval)
    {
        yield return new WaitForSeconds(interval / 1000);

        _ = CreateEnemy(enemyTemplate, new(Random.Range(-5f, 5f), Random.Range(-8f, 8f)));
        StartCoroutine(CoSpawnEnemy(enemyTemplate, interval));
    }

    private GameObject CreateEnemy(GameObject enemyTemplate, Vector2 position)
    {
        var clone = Instantiate(enemyTemplate, new(position.x, position.y), Quaternion.identity);
        _enemies.Add(clone);

        return clone;
    }
}
