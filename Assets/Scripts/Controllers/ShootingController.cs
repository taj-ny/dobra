using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ShootingController : MonoBehaviour
{
    [SerializeField]
    private GameObject _projectilePrefab;

    [SerializeField]
    private Transform _firingPoint;

    public void ShootProjectile()
    {
        var projectile = Instantiate(_projectilePrefab, _firingPoint.position, _firingPoint.rotation);
        var rigidbody = projectile.GetComponent<Rigidbody2D>();

        rigidbody.AddForce(_firingPoint.up * 15, ForceMode2D.Impulse);
    }
}
