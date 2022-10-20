using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class EnemyController : MonoBehaviour
{
    private Vector3 _boundingPosition;

    [SerializeField]
    private float _speed = 5f;

    [SerializeField]
    private WaveController _waveController;

    [SerializeField]
    private PlayerController _playerController;

    public bool ShouldDeleteOnBounds { get; private set; }

    void Start()
    {
        _boundingPosition = new(Random.Range(0f, 5f), Random.Range(0f, 5f));
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _boundingPosition, _speed * Time.deltaTime);
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
