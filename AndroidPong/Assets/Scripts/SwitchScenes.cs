using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchScenes : MonoBehaviour {
    
    public void PlayButton()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
