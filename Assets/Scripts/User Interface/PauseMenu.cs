using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pausePanel;

    public Button resumeButton;
    public Button helpButton;
    public Button mainMenuButton;
    public Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void ResumeButton()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void HelpButton()
    {
        
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
