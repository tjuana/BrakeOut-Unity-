using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaMenu : MonoBehaviour
{
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        Destroy(gameObject);
    }

    public void BackToMain()
    {
        Time.timeScale = 1f;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }

    void Start()
    {
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Handles the on click event from the Quit button
    /// </summary>
    public void HandleQuitButtonOnClickEvent()
    {
        // unpause game, destroy menu, and go to main menu
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }

    public void PlayClick()
    {
        AudioManager.Play(AudioClipName.Click);
    }
}
