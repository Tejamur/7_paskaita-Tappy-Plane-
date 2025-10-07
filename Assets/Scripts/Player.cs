using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce = 10;

    private int score = 0;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        // get component from the same game object script is on
        rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Point"))
        {
            score++;
            scoreText.text = score.ToString();
        }
    }
}
