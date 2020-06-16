using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves game object based on keyboard input
/// </summary>
public class Paddle : MonoBehaviour
{
    //timer 
    Timer timerFreezy;

    GameObject pausaMenu;
    GameObject pausaButton;
    int count = 0;
    //body movement
    Rigidbody2D body;
    Vector3 position;
    Vector2 velocityOfPaddle;
    float widthOfCollliderHalf;
    float x_pos;
    bool freezy = false;


    /// <summary>
    /// epta
    /// </summary>
    void Start()
    {
        //timer
        timerFreezy = gameObject.AddComponent<Timer>();
        //for body movement
        body = GetComponent<Rigidbody2D>();
        widthOfCollliderHalf = GetComponent<BoxCollider2D>().size.x / 2;

        EventManager.AddFreezerListener(Freezy);

        //pausa
        //pausaButton = GameObject.FindGameObjectWithTag("PausaButton");
        //pausaMenu = GameObject.FindWithTag("PausaMenu");
        //pausaMenu.SetActive(false);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void FixedUpdate()
	{
        MoveThePaddle();

        if (Input.GetAxis("Cancel") > 0)
            MenuManager.GoToMenu(MenuName.Pause);
	}

    /// <summary>
    /// Move and CalcClampX
    /// </summary>
    void MoveThePaddle()
    {
        if (!freezy)
        {
            
            // move horizontally as appropriate
            float horizontalInput = Input.GetAxis("Horizontal");
            if (horizontalInput > 0)
            {
                velocityOfPaddle = new Vector2(ConfigurationUtils.PaddleMoveUnitsPerSecond, 0f);
                if ((body.position.x + widthOfCollliderHalf) > ScreenUtils.ScreenRight)
                    velocityOfPaddle *= -0.17777f;
                body.MovePosition(body.position + velocityOfPaddle * Time.fixedDeltaTime);
            }
            if (horizontalInput < 0)
            {
                velocityOfPaddle = new Vector2(-ConfigurationUtils.PaddleMoveUnitsPerSecond, 0f);
                if ((body.position.x - widthOfCollliderHalf) < ScreenUtils.ScreenLeft)
                    velocityOfPaddle *= -0.17777f;
                body.MovePosition(body.position + velocityOfPaddle * Time.fixedDeltaTime);
            }
        }
    }

    public void Freezy(float duration)
    {
        timerFreezy.Duration = duration;
        timerFreezy.AddTimerFinishedEventListener(HandleHomingTimerFinishedEvent);
        AudioManager.Play(AudioClipName.FreezyActive);
        timerFreezy.Run();
        freezy = true;
    }

    void HandleHomingTimerFinishedEvent()
    {
        AudioManager.Play(AudioClipName.FreezyDisable);
        freezy = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            AudioManager.Play(AudioClipName.BallHit);
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                collision.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                widthOfCollliderHalf;
            float angleOffset = normalizedBallOffset * ConfigurationUtils.BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = collision.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }

}
