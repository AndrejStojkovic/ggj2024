using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Camera MainCamera;
    public float Weight = 0.5f;
    private float startingPosition;

    void Start()
    {
        startingPosition = transform.position.x;
    }

    void FixedUpdate()
    {
        Vector3 Position = MainCamera.transform.position;
        float val = Position.x - (1f - Weight);
        float distance = Position.x * Weight;
        transform.position = new Vector3(startingPosition + distance, transform.position.y, transform.position.z);
    }
}
