using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{

    public GameObject ProjectilePrefab;
    public Transform FirePoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        var projectile = Instantiate(ProjectilePrefab, FirePoint.position, FirePoint.rotation);
        var rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePoint.up * 15, ForceMode2D.Impulse);
    }


}
