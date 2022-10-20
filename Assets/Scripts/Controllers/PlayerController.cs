using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    private Vector2 _direction;
    [SerializeField] private float _speed = 5f;

    public int Health { get; set; } = 100;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _direction = RetriveMoveInput();
        _rigidBody.AddForce(_direction * _speed, ForceMode2D.Force);
    }
    
    public Vector2 RetriveMoveInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
   

}
