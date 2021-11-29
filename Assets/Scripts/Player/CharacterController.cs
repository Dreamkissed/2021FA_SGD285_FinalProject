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
    private int playerDamage = 50;
    private int enemyHealth = 50;
    private int enemyDamage = 10;

    // UI
    public Text playerHealthText;
    public GameObject gameOverPanel;

    // AUDIO
    public AudioSource gameOverSFX;
    public AudioSource jumpSFX;

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
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 7f), ForceMode2D.Impulse);
            jumpSFX.Play();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            playerHealth -= enemyDamage;
            playerHealthText.text = "Health: " + playerHealth.ToString();
        }
    }

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
