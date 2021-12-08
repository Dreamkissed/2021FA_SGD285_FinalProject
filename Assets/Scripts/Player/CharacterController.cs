using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public AudioSource gainedHealthSFX;

    // BOOLS
    private bool isColliding = false;

    public GameObject currentEnemy = null;
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        door.SetActive(false);
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

        // ATTACKING CONDITIONS
        if (Input.GetKeyDown(KeyCode.Q) && isColliding == true)
        {
            destroyedEnemySFX.Play();
            if(currentEnemy != null)
            {
                Destroy(currentEnemy);
                currentEnemy = null;
            }
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
        if (other.tag == "Enemy")
        {
            isColliding = true;
            currentEnemy = other.gameObject;

            hurtSFX.Play();
            playerHealth -= enemyDamage;
            playerHealthText.text = "Health: " + playerHealth.ToString();
        }

        if (other.tag == "Medkit" && playerHealth < 100)
        {
            gainedHealthSFX.Play();
            playerHealth = 100;
            playerHealthText.text = "Health: " + playerHealth.ToString();
            other.gameObject.SetActive(false);
        }
        if (other.tag == "Key")
        {
            door.SetActive(true);
            other.gameObject.SetActive(false);
        }
        if (other.tag == "Door")
        {
            //This will take you to the secret room in the game
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            isColliding = false;
            currentEnemy = null;
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
