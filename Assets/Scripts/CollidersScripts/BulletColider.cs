using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletColider : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
