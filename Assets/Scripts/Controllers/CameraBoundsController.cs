using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CameraBoundsController : MonoBehaviour
{
    void Start()
    {
        var camera = Camera.main!;

        var bottomLeft = camera.ScreenToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
        var topRight = 
            camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, camera.pixelHeight, camera.nearClipPlane));
        var topLeft = new Vector2(bottomLeft.x, topRight.y);
        var bottomRight = new Vector2(topRight.x, bottomLeft.y);

        camera.GetComponent<EdgeCollider2D>().points = new Vector2[] { bottomLeft, topLeft, topRight, bottomRight, bottomLeft };
    }
}
