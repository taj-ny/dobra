using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3 cameraPosition = Camera.main.transform.position;
        Camera.main.transform.position = new Vector3(mousePosition.x * 0.02f, mousePosition.y * 0.02f, Camera.main.transform.position.z);
    }
}
