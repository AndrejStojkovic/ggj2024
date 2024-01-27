using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    private static FadeController instance;
    public static FadeController Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.LogError("[ERROR] Fade Controller is not instantiated.");
            }
            return instance;
        }
    }

    public Image Fade;

    public UnityEvent<bool> OnFadeCompleted = new UnityEvent<bool>();

    private bool started = false;
    private float duration = 0f;
    private float startTime = 0f;
    private float currentTime = 0f;
    private bool state = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        state = false;
        startTime = 0f;
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if(!started)
        {
            return;
        }

        float value = (currentTime - startTime) / duration;
        Fade.color = new Color(0f, 0f, 0f, state ? value : 1f - value);

        if(value >= 1f)
        {
            started = false;
            OnFadeCompleted?.Invoke(state);
        }
    }

    public void FadeOut(float time)
    {
        duration = time;
        startTime = currentTime;
        state = true;
        Fade.color = new Color(0f, 0f, 0f, 0f);
        started = true;
    }

    public void FadeIn(float time)
    {
        duration = time;
        startTime = currentTime;
        state = false;
        Fade.color = new Color(0f, 0f, 0f, 1f);
        started = true;
    }
}
