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
        RepeatWidth = GetComponent<BoxCollider2D>().size.x / 2;
    }

    void Update()
    {
        if(transform.position.x < StartPosition.x - RepeatWidth) {
            transform.position = StartPosition;
        }
    }
}
