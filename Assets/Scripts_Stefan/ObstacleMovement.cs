using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float Speed;

    void FixedUpdate()
    {
        transform.Translate(Vector3.left * Speed, Camera.main.transform);
    }

    void OnBecameInvisible() {
	    Destroy(this.gameObject);
    }

}
