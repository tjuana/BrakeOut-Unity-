using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("game");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayClick()
    {
        AudioManager.Play(AudioClipName.Click);
    }
}
