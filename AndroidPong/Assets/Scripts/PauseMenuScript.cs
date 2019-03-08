using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseMenuScript : MonoBehaviour {

    private GameObject Pause;
    private GameObject Resume;
    private GameObject MainMenu;
    private GameObject Middle;

    private void Start()
    {
        Pause = GameObject.Find("PauseButton");
        Resume = GameObject.Find("ResumeButton");
        MainMenu = GameObject.Find("MainMenuButton");
        Middle = GameObject.Find("Middle");

        Pause.SetActive(true);
        Resume.SetActive(false);
        MainMenu.SetActive(false);
        Middle.SetActive(true);
    }
    public void PauseButton()
    {
        Time.timeScale = 0;
        Pause.SetActive(false);
        Resume.SetActive(true);
        MainMenu.SetActive(true);
        Middle.SetActive(false);
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        Pause.SetActive(true);
        Resume.SetActive(false);
        MainMenu.SetActive(false);
        Middle.SetActive(true);
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("MainMenu");
    }
}
