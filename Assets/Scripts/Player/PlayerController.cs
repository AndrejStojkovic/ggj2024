using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController instance;
    public static PlayerController Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.LogError("[ERROR] Player not instantiated.");
            }
            return instance;
        }
    }

    public Rigidbody2D rb;
    public float Speed = 10f;
    public Animator Animator;
    public float Scale = 1f;

    [Header("Dealing System")]
    public KeyCode DealKey;
    public float Radius = 2f;
    public LayerMask LayerMask;

    public int PendingMoney = 0;

    void Start()
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        PendingMoney = 0;
    }

    void Update()
    {
        var input = Input.GetAxisRaw("Horizontal");
        rb.AddForce(new Vector2(input * Speed * Time.deltaTime, 0f));
        Animator.Play(input == 0f ? "Idle" : "Walk");

        if(input != 0 && transform.localScale.x != input)
        {
            transform.localScale = new Vector3(input * Scale, Scale, Scale);
        }

        if(Input.GetKeyDown(DealKey))
        {
            Deal();
        }
    }

    public void Deal()
    {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, Radius, LayerMask);
        Debug.Log("[DEALING] Dealing!");

        for(int i = 0; i < collisions.Length; i++)
        {
            Debug.Log("Collision found: " + collisions[i].transform.name);

            Police police = collisions[i].GetComponentInParent<Police>();
            if(police != null)
            {
                // Report System
                Debug.Log("[DEALING] Don't deal to police officers!");
                break;
            }

            Junkie junkie = collisions[i].GetComponentInParent<Junkie>();
            if(junkie != null && junkie.Available)
            {
                if(junkie.Use())
                {
                    PendingMoney += junkie.Amount;
                }
                Debug.Log("[DEALING] Junkie found, using!", junkie.gameObject);
                break;
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
