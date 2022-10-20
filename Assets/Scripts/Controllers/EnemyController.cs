using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;

    [SerializeField]
    private WaveController _waveController;

    [SerializeField] private PlayerController _playerController;

    void Update()
    {
        var direction = new Vector2(1f, 0);
        transform.Translate(direction * Time.deltaTime * _speed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player" && _playerController.Health > 0)
        {
            _playerController.Health--;
            Debug.Log(_playerController.Health);
        }
        //if (collision)
        //{
            _waveController.RemoveEnemy(gameObject);
        //}
    }
}
