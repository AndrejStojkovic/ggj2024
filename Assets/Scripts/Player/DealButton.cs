using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DealButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PlayerController PlayerController;

    void Start()
    {
        if(PlayerController == null)
        {
            PlayerController = PlayerController.Instance;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        PlayerController.IsDealPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerController.IsDealPressed = false;
    }
}
