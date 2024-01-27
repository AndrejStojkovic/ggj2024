using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junkie : MonoBehaviour
{
    public Animator Animator;
    public bool Available = true;
    public int Amount = 1;

    public virtual bool Use()
    {
        Animator.Play("Deal");
        Available = false;
        return true;
    }
}
