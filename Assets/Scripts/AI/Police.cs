using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoliceState
{
    Idle,
    Walking
}

public class Police : MonoBehaviour
{
    private GameManager gm;
    private PlayerController PlayerController;

    public Rigidbody2D rb;
    public Animator Animator;

    private PoliceState previousState;
    public PoliceState State;

    public float Speed = 10f;

    public float Target;
    public float RestTime = 15f;

    public float CheckTime = 5f;
    public float Radius = 8f;
    public LayerMask LayerMask;

    private float startTime = 0f;
    
    void Start()
    {
        gm = GameManager.Instance;
        previousState = State = PoliceState.Idle;
        startTime = 0f;
    }

    void Update()
    {
        if(State == PoliceState.Idle && gm.CurrentGameTime > startTime + RestTime)
        {
            State = PoliceState.Walking;
        }
        else if(State == PoliceState.Walking)
        {
            int dir = Target > transform.position.x ? 1 : -1;
            transform.localScale = new Vector3(dir * transform.localScale.x, transform.localScale.y, transform.localScale.z);
            rb.AddForce(new Vector2(dir * Speed * Time.deltaTime, 0f));
        }
        else if(State == PoliceState.Walking && Vector3.Distance(new Vector3(Target, transform.position.y, transform.position.z), transform.position) < 1f)
        {
            State = PoliceState.Idle;
        }

        Animator.SetBool("IsIdle", State == PoliceState.Idle);
        previousState = State;
    }
}
