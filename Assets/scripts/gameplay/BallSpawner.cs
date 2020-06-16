using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    #region Fields

    [SerializeField]
    GameObject pfefabBall;
    //Timer
    Timer timerSpawn;

    //for Physics2D.OverlapArea
    bool retrySpawn = false;
    Vector2 spawnLocationMin;
    Vector2 spawnLocationMax;
    int spawn = 1;
    #endregion

    #region Constructor
    private void Start()
    {
        TempBallSize();
        GameObject ball = Instantiate<GameObject>(pfefabBall);

        //timers
        timerSpawn = gameObject.AddComponent<Timer>();
        timerSpawn.Duration = Random.Range(ConfigurationUtils.SpawnTimerMin, ConfigurationUtils.SpawnTimerMax);
        timerSpawn.AddTimerFinishedEventListener(HandleHomingTimerFinishedEvent);
        timerSpawn.Run();

        EventManager.AddListener(EventName.BallDiesEvent, SpawnBall);
    }

    void TempBallSize()
    {
        //for Physics2D.OverlapArea
        GameObject tempBall = Instantiate<GameObject>(pfefabBall);
        CircleCollider2D collider = tempBall.GetComponent<CircleCollider2D>();
        spawnLocationMin = new Vector2(
            tempBall.transform.position.x - collider.radius,
            tempBall.transform.position.y - collider.radius);
        spawnLocationMax = new Vector2(
            tempBall.transform.position.x + collider.radius,
            tempBall.transform.position.y + collider.radius);
        Destroy(tempBall);
    }

    #endregion

    #region Methods

    private void Update()
    {
        if (retrySpawn)
            SpawnBall(spawn);
    }

    void HandleHomingTimerFinishedEvent()
    {
        SpawnBall(spawn);
        timerSpawn.Duration = Random.Range(ConfigurationUtils.SpawnTimerMin, ConfigurationUtils.SpawnTimerMax);
        timerSpawn.Run();
    }

    void SpawnBall(int spawn)
    {
        if (Physics2D.OverlapArea(spawnLocationMin, spawnLocationMax) == null && spawn == 1)
        {
            GameObject ball = Instantiate<GameObject>(pfefabBall);
            Vector3 position = ball.transform.position;
            position.x = Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight);
            ball.transform.position = position;
            AudioManager.Play(AudioClipName.BallSpawn);
            retrySpawn = false;
        }
        else
            retrySpawn = true;
    }


    #endregion

}
