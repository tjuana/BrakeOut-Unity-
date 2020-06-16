using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore;

public class HUD : IntEventInvoker
{
    #region Fields
    [SerializeField]
    TMPro.TextMeshProUGUI scoreText;
    [SerializeField]
    TMPro.TextMeshProUGUI livesText;

    public int score;
    const string ScorePrefix = "SCORE : ";
    const string TimePrefix = "\n\n\n\n\n\n\nTIME : ";
    const string LivesPrefix = "LIVE : ";
    const string LivesPostfix = " / ";

    //GameOver help
    GameObject GameOver;
    GameObject[] blocks;
    int lives;


    int myTime = 0;
    float delta = 0;


    public bool stop = false;
    #endregion


    #region Properties

    /// <summary>
    /// Gets the score
    /// </summary>
    /// <value>the score</value>
    public int Score
    {
        get { return score; }
    }

    #endregion

    #region Constructor
    //The game keeps track of and displays the player’s score and the number of balls the player has
    //left to lose.

    void Start()
    {
        lives = ConfigurationUtils.Lives;
        scoreText.text = ScorePrefix + score.ToString() + TimePrefix + myTime.ToString();
        livesText.text = LivesPrefix + lives.ToString() + LivesPostfix + ConfigurationUtils.Lives.ToString();

        // add listener for PointsAddedEvent
        EventManager.AddListener(EventName.PointsAddedEvent, AddPoints);
        // add listener for HealthChangedEvent
        EventManager.AddListener(EventName.HealthChangedEvent, TakeLives);
        //GameOver
        unityEvents.Add(EventName.GameOverEvent, new HealthChangedEvent());
        EventManager.AddInvoker(EventName.GameOverEvent, this);

    }
    #endregion

    #region Methods
    private void Update()
    {
        delta += Time.deltaTime;
        if (delta > 1 && !stop)
        {
            myTime++;
            delta = 0;
        }
        scoreText.text = ScorePrefix + score.ToString() + TimePrefix + myTime.ToString();
        livesText.text = LivesPrefix + lives.ToString() + LivesPostfix + ConfigurationUtils.Lives.ToString();
    }


    /// <summary>
    /// Win the Game
    /// </summary>
    private void FixedUpdate()
    {
        blocks = GameObject.FindGameObjectsWithTag("Normal");
        if (blocks.Length == 0)
            MenuManager.GoToMenu(MenuName.GameOver);
    }

    void AddPoints(int points)
    {
        score += points;
        scoreText.text = ScorePrefix + score.ToString();
    }

    public void TakeLives(int live)
    {
        AudioManager.Play(AudioClipName.PlayerDeath);
        lives -= live;
        if (lives == 0)
        {
            //gameOver
            AudioManager.Play(AudioClipName.GameOver);
            MenuManager.GoToMenu(MenuName.GameOver);
        }
    }
    #endregion

}
