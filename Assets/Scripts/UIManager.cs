using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Buttons")]
    public Button startButton;
    public Button helpButton;
    public Button creditsButton;
    public Button quitButton;

    public Button backButton;

    [Header("Game Objects")]
    public GameObject helpPanel;
    public GameObject creditsPanel;

    [Header("Audio")]
    public AudioSource hoverSFX;
    public AudioSource clickSFX;

    // Start is called before the first frame update
    void Start()
    {
        helpPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Button Methods
    public void StartButton()
    {
        clickSFX.Play();
        SceneManager.LoadScene("MainLevel");
    }

    public void HelpButton()
    {
        clickSFX.Play();
        helpPanel.SetActive(true);
    }

    public void CreditsButton()
    {
        clickSFX.Play();
        creditsPanel.SetActive(true);
    }

    public void QuitButton()
    {
        clickSFX.Play();
        Application.Quit();
    }

    public void BackButton()
    {
        Start();
    }
}
