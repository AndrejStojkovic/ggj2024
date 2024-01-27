using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject[] Platform = new GameObject[3];
    public GameObject obstacle;
    private int previousRow = 1;
    public int row = 0;
    private int lives = 2;
    public int flag = 1;
    //public float jump;
    //private bool isJumping;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        previousRow = row;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && row < 2){
            row++;
        }

        if(Input.GetKeyDown(KeyCode.DownArrow) && row > 0){
            row--;
        }

        if(previousRow != row) {
            rb.MovePosition(new Vector2(rb.transform.position.x, Platform[row].transform.position.y));
        }

        previousRow = row;

        //if(Input.GetButtonDown("Jump") && !isJumping) {
        //    rb.gravityScale = 5;
        //    rb.AddForce(new Vector2(rb.velocity.x, jump));
        //    isJumping = true;
        //}

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);

        if(lives != 0){
            lives--;
        }

        // dumb check, but works :) 
        if(lives == 0){
            Debug.Log("Game over!");
            flag = 0;
        }
    }

    //void OnCollisionEnter2D(Collision2D other) {
    //    if (other.gameObject.CompareTag("Ground")) {
    //        isJumping = false;
    //        rb.gravityScale = 0;
    //    }
    //}
}