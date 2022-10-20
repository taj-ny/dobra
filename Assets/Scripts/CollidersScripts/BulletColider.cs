using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletColider : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colision detected");
        Destroy(gameObject);
    }
}
