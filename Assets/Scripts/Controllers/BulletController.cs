using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private Animation _impactAnimation = null;

    void OnCollisionEnter2D(Collision2D collision)
    {
        _impactAnimation.Play();
    }
}
