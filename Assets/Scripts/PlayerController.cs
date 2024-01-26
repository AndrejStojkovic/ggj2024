using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float Speed = 10f;

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
    }
}
