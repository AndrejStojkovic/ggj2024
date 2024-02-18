using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameCanvas : MonoBehaviour
{
    private static MainGameCanvas instance;
    public static MainGameCanvas Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.LogError("[ERROR] Main Game Canvas is not instantiated.");
            }
            return instance;
        }
    }

    private GameManager gm;

    public GameObject InfoView;
    public GameObject MoneyNotificationPrefab;
    public Transform NotificationTransform;
    public Transform NotificationParent;

    public GameObject ControlsView;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        gm = GameManager.Instance;
    }

    public void MoneyNotification(float amount)
    {
        GameObject go = Instantiate(MoneyNotificationPrefab, NotificationParent);
        go.transform.SetPositionAndRotation(NotificationTransform.position, NotificationTransform.rotation);
        Notification notification = go.GetComponentInParent<Notification>();
        notification.SetValue(gm.Price * amount);
    }

    public void SetView(bool target)
    {
        InfoView.SetActive(target);
        ControlsView.SetActive(target);
    }
}
