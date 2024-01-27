using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float Speed = 10f;

    [Header("Dealing System")]
    public KeyCode DealKey;
    public float Radius = 2f;
    public LayerMask LayerMask;

    void Start()
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        var input = Input.GetAxisRaw("Horizontal");
        rb.AddForce(new Vector2(input * Speed * Time.deltaTime, 0f));

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
            if(junkie != null)
            {
                junkie.Use();
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