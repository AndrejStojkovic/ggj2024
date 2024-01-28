using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    NONE = 0,
    RUNNING,
    PAUSED,
    CAUGHT,
    GAMEOVER
}

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
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

    public float GameTime = 90f;
    public GameState GameState;

    public int Day = 0;
    public int Money = 0;
    public int Price = 100;

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
        DontDestroyOnLoad(this);
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

    public void Pause(bool state)
    {
        if(state)
        {
            GameState = GameState.PAUSED;
            Time.timeScale = 0f;
        }
        else
        {
            GameState = GameState.RUNNING;
            Time.timeScale = 1f;
        }
    }
}
