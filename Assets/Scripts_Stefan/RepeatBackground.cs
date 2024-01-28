using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatCamera : MonoBehaviour
{
    public Vector3 StartPosition;
    public float RepeatWidth;
    
    void Start()
    {
        StartPosition = transform.position;
        RepeatWidth = gameObject.GetComponent<Renderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        if(transform.position.x < StartPosition.x - RepeatWidth) {
            transform.position = StartPosition;
        }
    }
}
