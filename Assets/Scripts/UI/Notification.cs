using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Notification : MonoBehaviour
{
    public TextMeshProUGUI Text;

    public void SetValue(float amount)
    {
        Text.text = "+$" + amount;
    }

    public void OnEnd()
    {
        Destroy(gameObject);
    }
}
