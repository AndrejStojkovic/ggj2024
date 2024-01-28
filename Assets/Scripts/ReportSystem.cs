using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportSystem : MonoBehaviour
{
    private static ReportSystem instance;
    public static ReportSystem Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.LogError("[ERROR] Report System is not instantiated.");
            }
            return instance;
        }
    }

    public static void Report()
    {
        var gm = GameManager.Instance;
        gm.GameState = GameState.CAUGHT;
        var player = PlayerController.Instance;
        player.CanMove = false;
        player.Animator.Play("Scared");
        // var camera = CameraController.Instance;
        FlexibleCameraSwitch.Instance.SwitchCam();
        MainGameCanvas.Instance.InfoView.SetActive(false);
    }
}
