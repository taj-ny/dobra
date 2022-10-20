using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    
    private WaveController _waveController;
    private PlayerController _playerController;
    
    public bool IsOnScreen { get; private set; }

    void Start()
    {
        _waveController = GameObject.Find("WaveObject").GetComponent<WaveController>();
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    
    void Update()
    {
        var direction = new Vector2(1f, 0);
        transform.Translate(direction * Time.deltaTime * _speed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.name);
        if (collision.collider.name == "Player" && _playerController.Health > 0)
        {
            _playerController.Health--;
            Debug.Log(_playerController.Health);
        }
        else if (collision.collider.name == "Main Camera")
        {
            Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);

            // if (!IsOnScreen)
            // {
            //     IsOnScreen = true;
            // }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.name == "Main Camera")
        {
            Invoke(nameof(DestroySelf), 1f);
        }
    }

    private void DestroySelf()
    {
        _waveController.RemoveEnemy(gameObject);
    }
}
