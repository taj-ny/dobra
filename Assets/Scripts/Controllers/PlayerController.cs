using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector2 direction;
    private Vector2 desiredVelocity;
    private Vector2 velocity;

    void Update()
    {
        direction.x = input.RetriveMoveInput();
        desiredVelocity = new Vector2(direction.x, 0f) * Mathf.Max(maxSpeed - ground.GetFriction(), 0f);
    }

}
