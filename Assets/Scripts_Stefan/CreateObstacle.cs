using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacle : MonoBehaviour
{
    public float wait = 0.5f;
    public GameObject Obstacle;
    public GameObject[] Platform = new GameObject[3];

    void Start()
    {
        InvokeRepeating("createObstacle", wait, wait);
    }

    void createObstacle() {
        int row =  Random.Range(0,3);
        
        Instantiate(Obstacle, new Vector3(10, Platform[row].transform.position.y, 0), Quaternion.identity);
    }
}
