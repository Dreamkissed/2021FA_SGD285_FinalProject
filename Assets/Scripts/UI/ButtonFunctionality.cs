using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonFunctionality : MonoBehaviour
{
    public Button startButton;
    public Button helpButton;
    public Button creditsButton;
    public Button backButton;
    public Button quitButton;

    public GameObject helpPanel;
    public GameObject creditsPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void HelpButton()
    {
        helpPanel.SetActive(true);
    }

    public void CreditsButton()
    {
        creditsPanel.SetActive(true);
    }

    public void BackButton()
    {
        helpPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
