using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnData
{
    public GameObject Prefab;
    public float Probability;
}

public class SpawnSystem : MonoBehaviour
{
    public string Name;
    public SpawnData[] Prefabs;
    public Collider Collider;
    public float MinDistance = 12f;
    public float Delay = 5f;
    public int MinPerSpawn = 1;
    public int MaxPerSpawn = 3;
    public int Cap = 20;
    public Vector3 Offset = new Vector3(0f, 1f, 0f);

    public int StartNum = 8;

    private GameManager gm;
    private Transform player;
    private PlayerController playerController;
    private float startTime;

    private List<GameObject> Spawned = new List<GameObject>();

    void Start()
    {
        gm = GameManager.Instance;
        playerController = PlayerController.Instance;
        player = PlayerController.Instance.transform;
        startTime = 0f;
        Spawned.Clear();
        Spawn(StartNum);
    }

    void Update()
    {
        if( gm.CurrentGameTime > startTime + Delay )
        {
            Spawn();
        }
    }

    public void Spawn(int target = -1)
    {
        if(Spawned.Count >= Cap)
        {
            return;
        }

        int count = Random.Range(MinPerSpawn, MaxPerSpawn + 1);
        int failSafe = 0;

        if(target != -1)
        {
            count = target;
        }

        for(int i = 0; i < count; i++)
        {
            float x = -1;
            Vector3 vector = Vector3.zero;

            while(x == -1 || Vector3.Distance(player.transform.position, vector) < MinDistance)
            {
                x = Random.Range(-Collider.bounds.extents.x, Collider.bounds.extents.x);
                vector = new Vector2(x, 0f);
                if(failSafe >= 10) break;
                failSafe++;
            }

            int idx = -1;
            float prob = Random.Range(0f, 1f);

            for(int j = 0; j < Prefabs.Length; j++)
            {
                if(prob < Prefabs[j].Probability)
                {
                    idx = j;
                    break;
                }
            }

            if(idx == -1)
            {
                idx = Prefabs.Length - 1;
            }

            GameObject go = Instantiate(Prefabs[idx].Prefab);
            go.transform.position = new Vector3(x, Offset.y, Offset.z);
            Spawned.Add(go);
        }

        startTime = gm.CurrentGameTime;
    }
}
