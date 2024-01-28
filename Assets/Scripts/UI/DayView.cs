using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayView : MonoBehaviour
{
    private GameManager gm;
    public TextMeshProUGUI Text;

    void Start()
    {
        gm = GameManager.Instance;
    }

    public void SetDay(int day)
    {
        Text.text = "DAY " + day;
    }
}
