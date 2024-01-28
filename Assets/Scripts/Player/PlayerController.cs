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

    public bool IsDealing = false;
    public bool CanMove = true;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        PendingMoney = 0;
        CanMove = true;
        IsDealing = false;
    }

    void Update()
    {
        if(CanMove)
        {
            var input = Input.GetAxisRaw("Horizontal");
            rb.AddForce(new Vector2(input * Speed * Time.deltaTime, 0f));
            Animator.SetBool("IsIdle", input == 0f);

            if(input != 0 && transform.localScale.x != input)
            {
                transform.localScale = new Vector3(input * Scale, Scale, 1f);
            }
        }

        if(Input.GetKeyDown(DealKey))
        {
            Deal();
            CanMove = false;
            IsDealing = true;
            Animator.SetBool("IsDealing", true);
        }

        if(Input.GetKeyUp(DealKey))
        {
            Animator.SetBool("IsDealing", false);
        }
    }

    public void OnDealingEnded()
    {
        Animator.SetBool("IsIdle", true);
        CanMove = true;
        IsDealing = false;
    }

    public void Deal()
    {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, Radius, LayerMask);
        Debug.Log("[DEALING] Dealing!");

        // Check if there is a police nearby, just in case
        for(int i = 0; i < collisions.Length; i++)
        {
            Police isPolice = collisions[i].GetComponentInParent<Police>();
            if(isPolice != null)
            {
                ReportSystem.Report();
                Debug.Log("[DEALING] A police office saw you nearby!");
                return;
            }
        }

        for(int i = 0; i < collisions.Length; i++)
        {
            Debug.Log("Collision found: " + collisions[i].transform.name);

            Police police = collisions[i].GetComponentInParent<Police>();
            if(police != null)
            {
                ReportSystem.Report();
                Debug.Log("[DEALING] Don't deal to police officers!");
                break;
            }

            Junkie junkie = collisions[i].GetComponentInParent<Junkie>();
            if(junkie != null && junkie.Available)
            {
                if(junkie.Use())
                {
                    PendingMoney += junkie.Amount * GameManager.Instance.Price;
                    MainGameCanvas.Instance.MoneyNotification(junkie.Amount);
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
