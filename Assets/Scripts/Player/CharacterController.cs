using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    // PLAYER PROPERTIES
    public float moveSpeed = 5f;
    public bool isGrounded = false;

    // HEALTH VALUES
    private int playerHealth = 100;
    private int enemyDamage = 10;

    // UI
    public Text playerHealthText;
    public GameObject gameOverPanel;

    // AUDIO
    public AudioSource gameOverSFX;
    public AudioSource jumpSFX;
    public AudioSource hurtSFX;
    public AudioSource destroyedEnemySFX;

    // BOOLS
    private bool isColliding = false;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        playerHealthText.text = "Health: " + playerHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        // Flip the character
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -1;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;

        GameOver();

        // TESTING PURPOSES
        if (Input.GetKeyDown(KeyCode.P))
        {
            playerHealth -= enemyDamage;
            playerHealthText.text = "Health: " + playerHealth.ToString();
        }

        // ATTACKING CONDITIONS
        if (Input.GetKeyDown(KeyCode.F) && isColliding == true)
        {
            destroyedEnemySFX.Play();
            Debug.Log("Enemy Destroyed");
        }
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 7f), ForceMode2D.Impulse);
            jumpSFX.Play();
        }
    }

    // COLLISIONS
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            isColliding = true;
            
            hurtSFX.Play();
            playerHealth -= enemyDamage;
            playerHealthText.text = "Health: " + playerHealth.ToString();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            isColliding = false;
        }
    }

    // GAME OVER
    void GameOver()
    {
        if (playerHealth <= 0)
        {
            gameOverPanel.SetActive(true);
            gameOverSFX.Play();
            gameOverSFX.Stop();
        }
    }
}
