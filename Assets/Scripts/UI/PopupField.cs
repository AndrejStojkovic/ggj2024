using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupField : MonoBehaviour
{
    public TextMeshPro Text;

    public void SetState(string text, bool state)
    {
        Text.text = text + "<size=24>x</size>";
        gameObject.SetActive(state);
    }
}
