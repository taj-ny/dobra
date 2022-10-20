using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private Vector2 _direction;

    [SerializeField]
    private float _speed = 5f;

    public int Health { get; set; } = 100;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //rotate to pointer with RotateToPointer
        RotateToPointer();
        _direction = RetriveMoveInput();
        _rigidBody.AddForce(_direction * _speed, ForceMode2D.Force);
    }
    
    public Vector2 RetriveMoveInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    
    public void RotateToPointer()
    {
        Vector3 _objectPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 _mousePos = Input.mousePosition;
        _mousePos -= _objectPos;
        float angle = Mathf.Atan2(_mousePos.y, _mousePos.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
