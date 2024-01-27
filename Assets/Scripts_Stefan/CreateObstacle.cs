using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacle : MonoBehaviour
{
    public float wait = 0.5f;
    public GameObject Obstacle;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("createObstacle", wait, wait);
    }

    void createObstacle() {
        Instantiate(Obstacle, new Vector3(10, Random.Range(-10, 10), 0), Quaternion.identity);
    }
}
