using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private PlayerStats instance;
    public PlayerStats Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.LogError("[ERROR] Player Stats is not instantiated");
            }
            return instance;
        }
    }

    [Min(0)]
    public int Price = 0;

    void Awake()
    {
        instance = this;
    }
}