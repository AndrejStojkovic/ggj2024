using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junkie : MonoBehaviour
{
    public bool Available = true;
    public int Amount = 1;

    public virtual bool Use()
    {
        Available = false;
        return true;
    }
}
