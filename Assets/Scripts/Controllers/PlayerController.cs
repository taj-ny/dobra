using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rbMovable;
    private Vector2 _direction;
    private ShootingController _shootingController;

    [SerializeField]
    private float _speed = 5f;

    public int Health { get; set; } = 100;

    private void Start()
    {
        _rbMovable = GetComponent<Rigidbody2D>();
        _shootingController = GetComponent<ShootingController>();
    }

    void Update()
    {
        // Rotate to pointer with RotateToPointer
        RotateToPointer();
        _direction = RetriveMoveInput();
        _rbMovable.AddForce(_direction * _speed, ForceMode2D.Force);

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            _shootingController.ShootProjectile();
        }
    }
    
    public Vector2 RetriveMoveInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    
    public void RotateToPointer()
    {
        var objectPos = Camera.main.WorldToScreenPoint(transform.position);
        var mousePos = Input.mousePosition - objectPos;

        var angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Health -= 50;
        }
    }
}
