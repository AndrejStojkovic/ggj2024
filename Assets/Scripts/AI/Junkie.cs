using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junkie : MonoBehaviour
{
    private GameManager gm;
    private Transform player;

    public Animator Animator;
    public bool Available = true;
    public int Amount = 1;
    public Vector2 AmountRange = new Vector2(0, 1);

    [Header("Pop-up")]
    public Vector2 IntervalRange = new Vector2(0f, 15f);
    // public GameObject Popup;
    private float popUpTime = 0f;
    private float popUpStart = 0f;
    private bool popUpSet = false;

    [Header("Spawning")]
    public float CheckDelay = 10f;
    public float MinDistanceForDespawn = 15f;
    private float lastTime = 0f;

    void Start()
    {
        gm = GameManager.Instance;
        player = PlayerController.Instance.transform;
        lastTime = 0f;
        popUpStart = 0f;
        popUpTime = Random.Range(IntervalRange.x, IntervalRange.y);
        popUpSet = false;
    }

    void Update()
    {
        if(!Available && gm.CurrentGameTime > lastTime + CheckDelay)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if(distance >= MinDistanceForDespawn)
            {
                Destroy(gameObject);
            }
        }

        if(!popUpSet && Available && gm.CurrentGameTime > popUpStart + popUpTime)
        {
            // Popup.SetActive(true);
            popUpSet = true;
        }
    }

    public virtual bool Use()
    {
        Animator.Play("Deal");
        Available = false;
        // Popup.SetActive(false);
        return true;
    }
}
