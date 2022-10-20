using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 _direction;
    [SerializeField] private float _speed = 5f;

    void Update()
    {
        _direction = RetriveMoveInput();
        GetComponent<Rigidbody2D>().AddForce(_direction * _speed, ForceMode2D.Force);
        // transform.Translate(_direction * Time.deltaTime * _speed);
    }
    
    public Vector2 RetriveMoveInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

}
