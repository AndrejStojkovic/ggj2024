using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
    public int MinAmount = 1;
    public int MaxAmount = 9;
    public Vector3 Offset = new Vector3(0f, 1f, 0f);

    public int StartNum = 8;

    private GameManager gm;
    private Transform player;
    private PlayerController playerController;
    private float startTime;

    public float StartTime
    {
        get
        {
            return startTime;
        }
        set
        {
            startTime = value;
        }
    }

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
            float originalScale = go.transform.localScale.x;
            float turned = Random.Range(0f, 1f);
            float mult = turned < 0.5f ? 1 : -1;
            go.transform.localScale = new Vector3(originalScale * mult, go.transform.localScale.y, go.transform.localScale.z);
            Spawned.Add(go);

            Junkie junkie = go.GetComponentInParent<Junkie>();

            if(junkie != null)
            {
                junkie.Amount = Random.Range(MinAmount, MaxAmount + 1);
                junkie.SetPopup(turned < 0.5f);
            }

            Police police = go.GetComponentInParent<Police>();
            
            if(police != null)
            {
                police.Parent = this;
            }
        }

        startTime = gm.CurrentGameTime;
    }
}
