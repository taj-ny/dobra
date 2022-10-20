using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CameraBoundsController : MonoBehaviour
{
    public Vector3 BottomLeft { get; private set; }
    public Vector3 TopRight { get; private set; }
    public Vector2 TopLeft { get; private set; }
    public Vector2 BottomRight { get; private set; }
    
    void Start()
    {
        var camera = Camera.main!;

        BottomLeft = camera.ScreenToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
        TopRight = camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, camera.pixelHeight, camera.nearClipPlane));
        TopLeft = new Vector2(BottomLeft.x, TopRight.y);
        BottomRight = new Vector2(TopRight.x, BottomLeft.y);

        camera.GetComponent<EdgeCollider2D>().points = new Vector2[] { BottomLeft, TopLeft, TopRight, BottomRight, BottomLeft };
    }
}
