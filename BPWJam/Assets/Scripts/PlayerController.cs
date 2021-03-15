using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f;
    public bool isGrounded = false;
    public GameObject deathScreen;
    float jumpTimer = 0;
    float controlTimer = 0;
    public int coins = 0;
    Rigidbody2D rb;
    //public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(!gm.isPaused){
        if (Input.GetKey(KeyCode.W))
            Jump();
    }

    void Jump()
    {
        if (isGrounded && jumpTimer <= 0)
        {
            jumpTimer = .2f;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            controlTimer = .7f;
        }
        else if(controlTimer > 0)
        {
            rb.AddForce(Vector2.up * jumpForce*60*Time.deltaTime);
        }
        jumpTimer -= Time.deltaTime;
        controlTimer -= Time.deltaTime;
    }

    void Die()
    {
        //Player Dies
        //gm.isPaused = true;
        PlayerPrefs.SetString("Coins", coins.ToString());
        deathScreen.SetActive(true);
        Debug.Log("Dead!");
    }


    //Collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "DeathBarrier")
        {
            Die();
        }
        if(collision.tag == "Coin")
        {
            coins += 1;
            Destroy(collision.gameObject);
        }
    }
}
