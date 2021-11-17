using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        playerHealthText.text = "Health: " + playerHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();

        // TESTING PURPOSES
        if (Input.GetKeyDown(KeyCode.P))
        {
            playerHealth -= enemyDamage;
            playerHealthText.text = "Health: " + playerHealth.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // PLAYER COLLIDES WITH ENEMY
        if(other.tag == "Enemy")
        {
            playerHealth -= enemyDamage;
            playerHealthText.text = "Health: " + playerHealth.ToString();
        }

        // PLAYER COLLIDES WITH KEY
        if (other.tag == "Key")
        {

        }
    }

    void GameOver()
    {
        if(playerHealth <= 0)
        {
            gameOverPanel.SetActive(true);
        }
    }
}
