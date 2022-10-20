using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BulletColider : MonoBehaviour
{

    [SerializeField]
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
