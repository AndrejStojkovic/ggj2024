using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float loopMax = 10f;
    public float loopMin = 0f;
    void Update() {
        transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0f, 0f);
        if (transform.position.x > loopMax) {
            transform.position += new Vector3 (loopMin - loopMax, 0f, 0f);
        }
    }
}
