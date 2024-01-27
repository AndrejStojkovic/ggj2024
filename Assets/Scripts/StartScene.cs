using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    public int StartScreen = 0;

    void Start()
    {
        SceneManager.Instance.OpenScene(StartScreen);
    }
}
