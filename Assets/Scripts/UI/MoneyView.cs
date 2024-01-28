using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MoneyView : MonoBehaviour
{
    private GameManager gm;
    private PlayerController pc;
    public TextMeshProUGUI MoneyText;

    void Start()
    {
        gm = GameManager.Instance;
        pc = PlayerController.Instance;
    }

    void Update()
    {
        // MoneyText.text = (gm.Money + pc.PendingMoney).ToString();
        MoneyText.text = String.Format("{0:n0}", gm.Money + pc.PendingMoney);
    }
}
