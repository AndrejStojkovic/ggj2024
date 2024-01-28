using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlexibleCameraSwitch : MonoBehaviour
{
    private static FlexibleCameraSwitch instance;
    public static FlexibleCameraSwitch Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.LogError("[ERROR] Flexible Camera Switch not instantiated.");
            }
            return instance;
        }
    }

    public GameObject[] cameraList;
    private int currentCamera;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentCamera = 0;
        for (int i = 0; i < cameraList.Length; i++)
        {
            cameraList[i].gameObject.SetActive(false);
        }
        if (cameraList.Length > 0)
        {
            cameraList[0].gameObject.SetActive(true);
        }
    }

    public void SwitchCam()
    {
        currentCamera++;
        cameraList[currentCamera - 1].gameObject.SetActive(false);
        cameraList[currentCamera].gameObject.SetActive(true);
    }
}
