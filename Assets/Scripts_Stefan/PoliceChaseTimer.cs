using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PoliceChaseTimer : MonoBehaviour
{
    private PoliceChaseScript gm;
    public TextMeshProUGUI TimerText;

    void Start()
    {
        gm = PoliceChaseScript.Instance;
    }

    void Update()
    {
        TimerText.text = GetTime(gm.GameTime - gm.CurrentGameTime);
    }

    private string GetTime(float time)
    {
        int minutes = (int)(time / 60);
        int seconds = (int)(time % 60);
        return System.String.Format("{0}:{1:00}", minutes, seconds);
    }
}
