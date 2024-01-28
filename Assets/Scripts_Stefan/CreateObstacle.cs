using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacle : MonoBehaviour
{
    public float wait = 0.5f;
    public GameObject[] Obstacles = new GameObject[4];
    public GameObject[] Platform = new GameObject[3];
    public GameObject Invincibility;
    public GameObject ExtraLife;
    private float shouldSpawnPowerUp;

    // if its 0.8 then we spawn invincibility
    // otherwise we spawn an extra life
    private float shouldSpawnInvincibility;

    // limits the number of times the invincibility power up
    // spawns for a run; currently its limited to only once per run
    private int invincibilitySpawnCounter = 0;

    void Start()
    {
        InvokeRepeating("createObstacle", wait, wait);
    }

    void createObstacle() {
        int row =  Random.Range(0,3);
        
        shouldSpawnPowerUp = Random.Range(0.0f, 1f);
        
        if (shouldSpawnPowerUp >= 0.95f) {
            shouldSpawnInvincibility = Random.Range(0.0f, 1f);

            if (shouldSpawnInvincibility >= 0.85f && invincibilitySpawnCounter == 0) {
                Instantiate(Invincibility, new Vector3(10, Platform[row].transform.position.y, 0), Quaternion.identity);
                invincibilitySpawnCounter++;
            } else {
                Instantiate(ExtraLife, new Vector3(10, Platform[row].transform.position.y, 0), Quaternion.identity);
            }
        } else {
            int obstacleToSpawn = Random.Range(0, 4);
            GameObject obstacle = Obstacles[obstacleToSpawn];

            Instantiate(obstacle, new Vector3(10, Platform[row].transform.position.y, 0), Quaternion.identity);
        }
    }
}
