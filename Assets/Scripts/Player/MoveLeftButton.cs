using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveLeftButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
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
        PlayerController.IsLeftPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerController.IsLeftPressed = false;
    }
}
