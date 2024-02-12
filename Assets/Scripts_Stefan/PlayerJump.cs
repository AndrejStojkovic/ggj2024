using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public PoliceChaseScript policeChaseScript;
    public Animator Animator;
    public Rigidbody2D rb;
    public GameObject[] Platform = new GameObject[3];
    public GameObject obstacle;
    private int previousRow = 1;
    public int row = 0;
    private int lives = 2;
    private bool hasInvincibility = false;
    private float invincibilityStartTime;
    private float currentGameTime;
    private float invincibilityDuration = 8f;
    public float CurrentGameTime
    {
        get
        {
            return currentGameTime;
        }
    }

    public GameState GameState;

    public int DeathScene = 5;

    //public float jump;
    //private bool isJumping;

    void Start()
    {
        currentGameTime = 0;
        rb = GetComponentInChildren<Rigidbody2D>();
        previousRow = row;
        if(policeChaseScript)
        {
            policeChaseScript = PoliceChaseScript.Instance;
        }
    }

    void Update()
    {
        currentGameTime += Time.deltaTime;

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

        if (
            hasInvincibility 
                && (currentGameTime - invincibilityStartTime) / invincibilityDuration >= 1f
        ) {
            hasInvincibility = false;
        }

        //if(Input.GetButtonDown("Jump") && !isJumping) {
        //    rb.gravityScale = 5;
        //    rb.AddForce(new Vector2(rb.velocity.x, jump));
        //    isJumping = true;
        //}

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        string tag = other.tag;

        Destroy(other.gameObject);

        switch(tag) {
            case "Obstacle":
                if (!hasInvincibility) {
                    policeChaseScript.Animator.speed = 0f;
                    Animator.Play("Hit");
                    Debug.Log("Game over!");
                    GameState = GameState.GAMEOVER;
                }
                break;
            case "ExtraLife":
                // only allow a maximum of 2 lives per run
                if (lives < 2) {
                    lives++;
                }
                break;
            case "Invincibility":
                hasInvincibility = true;
                invincibilityStartTime = currentGameTime;
                break;
        }
    }

    public void OnGracePeriodEnd()
    {
        SceneManager.Instance.OpenScene(DeathScene);
    }

    //void OnCollisionEnter2D(Collision2D other) {
    //    if (other.gameObject.CompareTag("Ground")) {
    //        isJumping = false;
    //        rb.gravityScale = 0;
    //    }
    //}
}
