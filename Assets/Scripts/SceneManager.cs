using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    private static SceneManager instance;
    public static SceneManager Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.LogError("[ERROR] Scene Manager is not instantiated.");
            }
            return instance;
        }
    }

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    public void OpenScene(int idx)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(idx);
    }
}
