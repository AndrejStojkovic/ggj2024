using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseSystem : MonoBehaviour
{
    public GameObject PauseView;
    public Button ResumeButton;
    public Button QuitButton;
    public MainGameCanvas MainGameCanvas;

    private GameManager gm;
    private bool state = false;

    public bool State
    {
        get
        {
            return state;
        }
        set
        {
            state = value;
        }
    }

    void Start()
    {
        gm = GameManager.Instance;
        state = false;
        PauseView.SetActive(state);
        ResumeButton.onClick.AddListener(Resume);
        QuitButton.onClick.AddListener(Quit);
    }

    // void Update()
    // {
    //     if(Input.GetKeyDown(KeyCode.Escape))
    //     {
    //         state = !state;
    //         Refresh();
    //     }
    // }

    public void Pause()
    {
        state = true;
        Refresh();
    }

    void Refresh()
    {
        gm.Pause(state);
        PauseView.SetActive(state);
        MainGameCanvas.SetView(!state);
    }

    public void Resume()
    {
        state = false;
        Refresh();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
