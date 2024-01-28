using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PopupManager : MonoBehaviour
{
    public Junkie AI;
    public PopupField Left;
    public PopupField Right;

    void Start()
    {
        if(AI == null)
        {
            AI = GetComponentInParent<Junkie>();
        }
    }

    public void SetPopup(bool state)
    {
        Left.SetState(AI.Amount.ToString(), state);
        Right.SetState(AI.Amount.ToString(), !state);
    }
}
