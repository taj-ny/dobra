using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyTemplate1;
    private List<Wave> _waves;
    private bool _isRunning;
    private IEnumerator<Wave> _waveEnumerator;

    // Start is called before the first frame update
    void Start()
    {
        var spawner = GameObject.Find("SpawnerObject").GetComponent<EnemySpawnerController>();
        _waves = new() // wtf
        {
            new(new()
            {
                { _enemyTemplate1, 5 }
            }, gameObject.AddComponent<EnemySpawnerController>(), 4000f),
            new(new()
            {
                { _enemyTemplate1, 10 }
            }, gameObject.AddComponent<EnemySpawnerController>(), 3000f),
            new(new()
            {
                { _enemyTemplate1, 15 }
            }, gameObject.AddComponent<EnemySpawnerController>(), 2000f),
            new(new()
            {
                { _enemyTemplate1, 20 }
            }, gameObject.AddComponent<EnemySpawnerController>(), 1000f)
        };
        _waveEnumerator = _waves.GetEnumerator();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isRunning)
        {
            _isRunning = true;
            _waveEnumerator.MoveNext();
            
            _waveEnumerator.Current?.GraduallySpawnEnemies();
        }
    }
    
    public void RemoveEnemy(GameObject enemy)
    {
        var currentWave = _waveEnumerator.Current;
        currentWave.Spawner.DestroyEnemy(enemy, x =>
        {
            if (!currentWave.Spawner.AreAnyEnemiesAlive)
                _isRunning = false;
        });
    }
}

public sealed class Wave
{
    // EnemyTemplate | EnemyCount
    private readonly Dictionary<GameObject, int> _enemiesToSpawn;
    private readonly float _spawnInterval;

    public EnemySpawnerController Spawner { get; }

    public Wave(Dictionary<GameObject, int> enemiesToSpawn, EnemySpawnerController spawner, float spawnInterval)
    {
        _enemiesToSpawn = enemiesToSpawn;
        Spawner = spawner;
        _spawnInterval = spawnInterval;
    }

    public void GraduallySpawnEnemies()
    {
        foreach (var item in _enemiesToSpawn)
        {
            Spawner.QueueEnemySpawn(item.Key, item.Value, _spawnInterval);
        }
    }
}