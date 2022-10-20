using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public sealed class EnemyController : MonoBehaviour
{
    private Vector3 _boundingPosition;
    private ShootingController _shootingController;
    private PlayerController _playerController;
    private bool _shootingRoutineStarted;

    [SerializeField]
    private float _speed = 5f;
    
    private WaveController _waveController;
    

    public bool ShouldDeleteOnBounds { get; private set; }

    void Start()
    {
        _waveController = GameObject.Find("WaveObject").GetComponent<WaveController>();
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _shootingController = GetComponent<ShootingController>();
        _boundingPosition = new(Random.Range(0f, 5f), Random.Range(0f, 5f));
    }
    
    void Update()
    {
        RotateToPlayer();

        transform.position = Vector3.MoveTowards(transform.position, _boundingPosition, _speed * Time.deltaTime);
        
        if (!ShouldDeleteOnBounds && !_shootingRoutineStarted)
        {
            _shootingRoutineStarted = true;
            StartCoroutine(CoShootProjectile(2000f));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.collider.tag)
        {
            case "Enemy":
            case "EnemyBullet":
                Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
                break;

            case "Player":
            case "Bullet":
                DestroySelf();
                break;

            case "MainCamera":
                Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
                if (!ShouldDeleteOnBounds)
                {
                    ShouldDeleteOnBounds = true;
                    return;
                }
            
                Invoke(nameof(DestroySelf), 1f);
                break;
        }
    }

    private IEnumerator CoShootProjectile(float interval)
    {
        yield return new WaitForSeconds(interval / 1000);

        _shootingController.ShootProjectile();
        StartCoroutine(CoShootProjectile(interval));
    }

    private void DestroySelf()
    {
        StopAllCoroutines();
        _waveController.RemoveEnemy(gameObject);
    }

    private void RotateToPlayer()
    {
        var objectPos = Camera.main.WorldToScreenPoint(transform.position);
        var playerPos = Camera.main.WorldToScreenPoint(_playerController.transform.position) - objectPos;

        var angle = Mathf.Atan2(playerPos.y, playerPos.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
