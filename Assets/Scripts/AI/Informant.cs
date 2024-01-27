using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Informant : Junkie
{
    public float ReportChance = 0.1f;

    public override bool Use()
    {
        float rand = Random.Range(0f, 1f);
        if(rand < ReportChance)
        {
            //ReportManager.Report();
            Debug.Log("An Informant reported you!");
            return false;
        }

        return base.Use();
    }
}
