using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystemFixed : MonoBehaviour
{
    public string Name;
    public SpawnData SpawnData;
    public Transform[] Locations;
    public float Probability = 0.2f;

    private List<GameObject> Spawned = new List<GameObject>();

    void Start()
    {
        Spawned.Clear();
        for(int i = 0; i < Locations.Length; i++)
        {
            float rand = Random.Range(0f, 1f);
            if(rand < Probability)
            {
                GameObject go = Instantiate(SpawnData.Prefab);
                float originalScale = go.transform.localScale.x;
                go.transform.position = Locations[i].position;
                float turned = Random.Range(0f, 1f);
                float newScale = originalScale * (turned < 0.5f ? 1 : -1);
                go.transform.localScale = new Vector3(newScale, go.transform.localScale.y, go.transform.localScale.z);
                Spawned.Add(go);
            }
        }
    }
}
