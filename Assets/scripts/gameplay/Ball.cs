using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : IntEventInvoker
{


    Rigidbody2D body;
    Vector2 velocity;


    //timers
    Timer timerDeath;
    Timer timerFreezBall;


    bool speedFlag = false;

    bool deathBall = false;
    Vector2 moveDirection;

    int live = 1;

    int spawn = 1;
    /// <summary>
    /// INIT
    /// </summary>
    void Start()
    {

        body = GetComponent<Rigidbody2D>();

        //angle

        float angle = Random.Range(40 * Mathf.Deg2Rad, 120 * Mathf.Deg2Rad);

        //direction for spawn
        moveDirection = new Vector2(ConfigurationUtils.BallImpulseForce * Mathf.Cos(angle),
                                    ConfigurationUtils.BallImpulseForce * Mathf.Sin(angle));

        //speedyBall
        EventManager.AddSpeddyListener(Speeder);

        //timers
        timerFreezBall = gameObject.AddComponent<Timer>();
        timerFreezBall.Duration = ConfigurationUtils.TimerFreezy;
        timerFreezBall.AddTimerFinishedEventListener(HandleHomingTimerFreezFinishedEvent);
        timerFreezBall.Run();


        timerDeath = gameObject.AddComponent<Timer>();
        timerDeath.Duration = ConfigurationUtils.DeathTimer;
        timerDeath.AddTimerFinishedEventListener(HandleHomingTimerDeathFinishedEvent);
        timerDeath.Run();


        unityEvents.Add(EventName.HealthChangedEvent, new HealthChangedEvent());
        EventManager.AddInvoker(EventName.HealthChangedEvent, this);
        unityEvents.Add(EventName.BallDiesEvent, new BallDiesEvent());
        EventManager.AddInvoker(EventName.BallDiesEvent, this);

    }

    public void SetDirection(Vector2 moveDirection)
    {
        body = GetComponent<Rigidbody2D>();
        body.AddForce(moveDirection * body.velocity.magnitude,
                        ForceMode2D.Force);
    }

    private void Update()
    {
        //stop speedy
        if (!EffectUtils.ActiveSpeed && speedFlag)
        {
            body = GetComponent<Rigidbody2D>();
            velocity = body.velocity;
            velocity /= ConfigurationUtils.SpeedFactor;
            body.velocity = velocity;
            AudioManager.Play(AudioClipName.SpeedBallDisable);
            speedFlag = false;
        }
    }

    void HandleHomingTimerFreezFinishedEvent()
    {
        if (EffectUtils.ActiveSpeed)
        {
            moveDirection *= ConfigurationUtils.SpeedFactor;
            speedFlag = true;
        }
        body.AddForce(moveDirection);
    }

    void HandleHomingTimerDeathFinishedEvent()
    {
        unityEvents[EventName.BallDiesEvent].Invoke(spawn);
        if (gameObject != null)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.Play(AudioClipName.BallHit);
    }

    public void Speeder(float duration, float speedUpFactor)
    {
        AudioManager.Play(AudioClipName.SpeedBallActive);
        if (!speedFlag)
        {
            body = GetComponent<Rigidbody2D>();
            velocity = body.velocity;
            velocity *= speedUpFactor;
            body.velocity = velocity;
            speedFlag = true;
        }
    }

    private void OnBecameInvisible()
    {
        if (gameObject != null && gameObject.transform.position.y < ScreenUtils.ScreenBottom)
        {
            unityEvents[EventName.HealthChangedEvent].Invoke(live);
            unityEvents[EventName.BallDiesEvent].Invoke(spawn);
            EventManager.RemoveInvoker(EventName.HealthChangedEvent, this);
            EventManager.RemoveInvoker(EventName.BallDiesEvent, this);
            Destroy(gameObject);
        }
    }
}
