using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedParticleStart : MonoBehaviour
{
    public ParticleSystem ParticleSystem;
    public float Delay = 1f;

    void Start()
    {
        ParticleSystem.Stop();
        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(Delay);
        ParticleSystem.Play();
    }
}
