using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce = 10;

    private int score = 0;
    public TextMeshProUGUI scoreText;

    private AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip deathSound;

    public GameObject spawner;
    public Scoreboard scoreBoard;

    private void Start()
    {
        // get component from the same game object script is on
        rb = GetComponent<Rigidbody2D>();

        audioSource = GetComponent<AudioSource>();
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            audioSource.PlayOneShot(jumpSound);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        scoreBoard.ShowScore(score);
        audioSource.PlayOneShot(deathSound);
        spawner.SetActive(false); //disable
        Destroy(this); // remove player script

    }
}
