using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealingSystem : MonoBehaviour
{
    private PlayerController playerController;

    void Start()
    {
        playerController = PlayerController.Instance;
    }
}
