using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UnityEvent;

public class GameOver : MonoBehaviour
{

    [SerializeField]
    TMPro.TextMeshProUGUI scoreText;
    const string ScorePrefix = "YOURE SCORE IS :    ";
    int points = 0;
    GameObject hud;

    public void BackToMain()
    {
        Time.timeScale = 1f;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }

    void Start()
    {
        hud = GameObject.FindWithTag("HUD");
        points = hud.GetComponent<HUD>().Score;
        Time.timeScale = 0f;
        scoreText.text = ScorePrefix + points;
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
