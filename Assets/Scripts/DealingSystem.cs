using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealingSystem : MonoBehaviour
{
    private PlayerController playerController;
    public SpawnSystem PoliceSpawnSystem;
    public float DecreasePerDeal = 5f;
    public float FailChance = 0.1f;

    void Start()
    {
        playerController = PlayerController.Instance;
        playerController.OnDealingStateChange.AddListener(OnDealStateChanged);
    }

    public void OnDealStateChanged(bool newState)
    {
        float prob = Random.Range(0f, 1f);
        if(!newState || prob < FailChance)
        {
            return;
        }

        PoliceSpawnSystem.StartTime -= DecreasePerDeal;
    }
}
