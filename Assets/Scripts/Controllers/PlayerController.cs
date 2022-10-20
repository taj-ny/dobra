using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public sealed class PlayerController : MonoBehaviour
{
    private Vector2 _direction;
    private Rigidbody2D _rbMovable;
    private ShootingController _shootingController;

    [SerializeField]
    private float _speed = 5f;

    private Slider _healthBar;

    public int Health { get; set; } = 100;

    private void Start()
    {
        _rbMovable = GetComponent<Rigidbody2D>();
        _shootingController = GetComponent<ShootingController>();
        _healthBar = FindObjectOfType<Slider>();
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
    
    private void RotateToPointer()
    {
        var objectPos = Camera.main.WorldToScreenPoint(transform.position);
        var mousePos = Input.mousePosition - objectPos;

        var angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.name);
        switch (collision.collider.tag)
        {
            case "Enemy":
                Health -= 50;
                break;

            case "EnemyBullet":
                Health -= 15;
                break;
        }
        _healthBar.value = (float) Health / 100;

        if (Health <= 0)
        {
            SceneManager.LoadScene(sceneName:"DeathScreen");
        }
    }
}
