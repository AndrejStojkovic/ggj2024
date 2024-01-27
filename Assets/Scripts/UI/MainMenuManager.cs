using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public float Delay = 1f;
    public float FadeDuration = 2f;

    public int MainGameIdx = 1;

    private FadeController fadeController;
    private bool canStart = false;

    void Start()
    {
        fadeController = FadeController.Instance;
        fadeController.Fade.color = Color.black;
        StartCoroutine(DelayedStart(Delay));
    }

    void Update()
    {
        if(canStart && Input.anyKeyDown)
        {
            Debug.Log("Start Game!");
            fadeController.OnFadeCompleted.AddListener(OnFadeInEnded);
            fadeController.FadeOut(FadeDuration);
        }
    }

    public void OnFadeOutEnded(bool state)
    {
        canStart = true;
        fadeController.OnFadeCompleted.RemoveListener(OnFadeOutEnded);
    }

    public void OnFadeInEnded(bool state)
    {
        SceneManager.Instance.OpenScene(MainGameIdx);
    }

    IEnumerator DelayedStart(float delay)
    {
        yield return new WaitForSeconds(delay);
        fadeController.OnFadeCompleted.AddListener(OnFadeOutEnded);
        fadeController.FadeIn(FadeDuration);
        canStart = false;
        yield return null;
    }
}
