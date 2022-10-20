using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Resources.Load<GameObject>("Assets/Prefabs/HealthBar_LR"), transform.position, Quaternion.identity, transform);
    }

    // Update is called once per frame
    void Update()
    {
           
    }
}
