using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    public bool IsLeftPressed = false;
    public bool IsRightPressed = false;
    public bool IsDealPressed = false;
    private bool lastDealPressed = false;

    public UnityEvent<bool> OnDealingStateChange = new UnityEvent<bool>();

    void Awake()
    {
        instance = this;
        lastDealPressed = IsDealPressed;
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
            float input = IsRightPressed ? 1f : IsLeftPressed ? -1f : 0f;
            if(IsRightPressed && IsLeftPressed) input = 0f;
            rb.AddForce(new Vector2(input * Speed * Time.deltaTime, 0f));
            Animator.SetBool("IsIdle", input == 0f);

            if(input != 0 && transform.localScale.x != input)
            {
                transform.localScale = new Vector3(input * Scale, Scale, 1f);
            }
        }

        if(!lastDealPressed && IsDealPressed)
        {
            CanMove = false;
            Animator.SetBool("IsDealing", true);
        }

        if(lastDealPressed && !IsDealPressed)
        {
            Animator.SetBool("IsDealing", false);
        }

        lastDealPressed = IsDealPressed;
    }

    public void StartDealing()
    {
        Deal();
        IsDealing = true;
        OnDealingStateChange.Invoke(IsDealing);
    }

    public void OnDealingEnded()
    {
        Animator.SetBool("IsIdle", true);
        CanMove = true;
        IsDealing = false;
        OnDealingStateChange.Invoke(IsDealing);
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

        float total = 0f;

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
                    total += junkie.Amount;
                }
                Debug.Log("[DEALING] Junkie found, using!", junkie.gameObject);
            }
        }

        MainGameCanvas.Instance.MoneyNotification(total);
    }

    public void OnCaught()
    {
        SceneManager.Instance.OpenScene(GameManager.Instance.PoliceChaseScene);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
