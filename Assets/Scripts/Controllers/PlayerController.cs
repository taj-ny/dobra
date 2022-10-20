using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 _direction;
    [SerializeField] private float _speed = 5f;

    void Update()
    {
        //rotate to pointer with RotateToPointer
        RotateToPointer();
        _direction = RetriveMoveInput();
        transform.Translate(_direction * Time.deltaTime * _speed);
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
        float angle = Mathf.Atan2(_mousePos.y, _mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
