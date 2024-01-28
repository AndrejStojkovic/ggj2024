using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manhole : MonoBehaviour
{
    private PlayerController playerController;
    public bool IsActive = false;
    public Animator Animator;
    public float PercentToActivate = 0.2f;
    public float Radius = 5f;
    public LayerMask LayerMask;

    void Start()
    {
        IsActive = false;
        playerController = PlayerController.Instance;
        playerController.OnDealingStateChange.AddListener(OnDealingChanged);
    }

    public void OnDealingChanged(bool newState)
    {
        float prob = Random.Range(0f, 1f);
        if(prob < PercentToActivate)
        {
            IsActive = true;
            Animator.Play("Loop");
        }
    }

    public void OnManholeCheck()
    {
        if(!IsActive)
        {
            return;
        }

        Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, Radius, LayerMask);

        for(int i = 0; i < collisions.Length; i++)
        {
            PlayerController player = collisions[i].GetComponentInParent<PlayerController>();
            if(player != null && player.IsDealing)
            {
                ReportSystem.Report();
            }
        }
    }
}
