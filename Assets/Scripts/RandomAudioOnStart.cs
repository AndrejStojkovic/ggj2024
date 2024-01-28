using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudioOnStart : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip[] AudioClips;

    public enum StartType
    {
        OnAwake,
        OnStart
    }

    public StartType Type;

    void Awake()
    {
        if(Type == StartType.OnAwake)
        {
            Generate();
        }
    }

    void Start()
    {
        if(Type == StartType.OnStart)
        {
            Generate();
        }
    }

    private void Generate()
    {
        int idx = Random.Range(0, AudioClips.Length);
        AudioSource.clip = AudioClips[idx];
        AudioSource.Play();
    }
}
