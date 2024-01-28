using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private static CameraController instance;
    public static CameraController Instance
    {
        get
        {
            return instance;
        }
    }

    public Transform Target;
    public Vector3 Offset;
    public float SmoothTime = 0.2f;
    public Vector2 Clamp;

    private Vector3 velocity;

    void Awake()
    {
        instance = this;
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(Mathf.Clamp(Target.position.x, Clamp.x, Clamp.y), Target.position.y, 0f);
        targetPosition += Offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);
    }
}
