using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class EnemyController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    void Update()
    {
        var direction = new Vector2(1f, 0);
        transform.Translate(direction * Time.deltaTime * _speed);
    }
}
