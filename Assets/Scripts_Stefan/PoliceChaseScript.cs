using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceChaseScript : MonoBehaviour
{
    private static PoliceChaseScript instance;
    public static PoliceChaseScript Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.LogError("[ERROR] Game Manager not instantiated.");
            }
            return instance;
        }
    }

    public float GameTime = 30f;
    public GameState GameState;

    public Animator Animator;

    public float CurrentGameTime
    {
        get
        {
            return currentGameTime;
        }
    }

    private float currentGameTime;

    private void Awake() {
        // if(GameManager.Instance != null)
        // {
        //     Debug.LogError("[ERROR] Game Manager already exists!");
        //     return;
        // }
        instance = this;
    }

    void Start()
    {
        currentGameTime = 0;
        GameState = GameState.RUNNING;
    }

    void Update()
    {
        if(GameState != GameState.RUNNING)
        {
            return;
        }

        currentGameTime += Time.deltaTime;

        if(currentGameTime > GameTime)
        {
            GameState = GameState.GAMEOVER;
        }
    }
}
