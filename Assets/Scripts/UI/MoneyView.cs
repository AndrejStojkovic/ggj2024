using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyView : MonoBehaviour
{
    private GameManager gm;
    public TextMeshProUGUI MoneyText;

    void Start()
    {
        gm = GameManager.Instance;
    }

    void Update()
    {
        MoneyText.text = "$" + gm.Money.ToString();
    }
}
