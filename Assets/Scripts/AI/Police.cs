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

    public SpawnSystem Parent;

    public float Speed = 10f;

    public float Target;
    public float StopDistance = 0.1f;
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
        Vector3 targetVector = new Vector3(Target, transform.position.y, transform.position.z);
        if(State == PoliceState.Idle && gm.CurrentGameTime > startTime + RestTime)
        {
            GenerateTarget();
            State = PoliceState.Walking;
        }
        else if(State == PoliceState.Walking && (transform.position - targetVector).magnitude <= StopDistance)
        {
            State = PoliceState.Idle;
            startTime = gm.CurrentGameTime;
        }
        else if(State == PoliceState.Walking)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetVector, Speed * Time.deltaTime);
            // rb.AddForce(new Vector2(dir * Speed * Time.deltaTime, 0f));
        }

        Animator.SetBool("IsIdle", State == PoliceState.Idle);
        previousState = State;
    }

    public void GenerateTarget()
    {
        float val = Parent.Collider.bounds.extents.x;
        Target = Random.Range(-val, val);
        int dir = Target > transform.position.x ? 1 : -1;
        transform.localScale = new Vector3(dir * transform.localScale.x, transform.localScale.y, transform.localScale.z);
        Debug.Log("New Direction: " + dir + ", (" + Target + " " + transform.position.x + ")", gameObject);
    }
}
