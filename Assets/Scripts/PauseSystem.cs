using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseSystem : MonoBehaviour
{
    public GameObject PauseView;
    public Button ResumeButton;
    public Button QuitButton;

    private GameManager gm;
    private bool state = false;

    void Start()
    {
        gm = GameManager.Instance;
        state = false;
        PauseView.SetActive(state);
        ResumeButton.onClick.AddListener(Resume);
        QuitButton.onClick.AddListener(Quit);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            state = !state;
            Refresh();
        }
    }

    void Refresh()
    {
        gm.Pause(state);
        PauseView.SetActive(state);
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
