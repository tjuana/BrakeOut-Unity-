using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A timer
/// </summary>
public class Timer : MonoBehaviour
{
	#region Fields
	
	// timer duration
	float totalSeconds = 0;
	
	// timer execution
	float elapsedSeconds = 0;
	bool running = false;

    float leftTime = 0;
	// support for Finished property
	bool started = false;

    // events invoked by class
    TimerFinishedEvent timerFinishedEvent = new TimerFinishedEvent();

    #endregion

    #region Properties

    /// <summary>
    /// Sets the duration of the timer
    /// The duration can only be set if the timer isn't currently running
    /// </summary>
    /// <value>duration</value>
    public float Duration
    {
        set
        {
            if (!running)
            {
                totalSeconds = value;
            }
            else if (started && running)
            {
                totalSeconds  += value;
            }
		}
	}
	
	/// <summary>
	/// Gets whether or not the timer has finished running
	/// This property returns false if the timer has never been started
	/// </summary>
	/// <value>true if finished; otherwise, false.</value>
	public bool Finished
    {
		get { return started && !running; } 
	}
	
	/// <summary>
	/// Gets whether or not the timer is currently running
	/// </summary>
	/// <value>true if running; otherwise, false.</value>
	public bool Running
    {
		get { return running; }
	}

    public float LeftTime
    {
        get { return leftTime; }
    }
    #endregion

    #region Methods

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {	
		// update timer and check for finished
		if (running)
        {
            leftTime = (int)Mathf.Ceil(totalSeconds - elapsedSeconds);
            elapsedSeconds += Time.deltaTime;
			if (elapsedSeconds >= totalSeconds)
            {
				running = false;
                leftTime = 0;
                timerFinishedEvent.Invoke();
            }   
        }
	}

    /// <summary>
    /// Adds the given event handler as a listener
    /// </summary>
    /// <param name="handler">the event handler</param>
    public void AddTimerFinishedEventListener(UnityAction handler)
    {
        timerFinishedEvent.AddListener(handler);
    }

    /// <summary>
    /// Runs the timer
    /// Because a timer of 0 duration doesn't really make sense,
    /// the timer only runs if the total seconds is larger than 0
    /// This also makes sure the consumer of the class has actually 
    /// set the duration to something higher than 0
    /// </summary>
    public void Run()
    {	
		// only run with valid duration
		if (totalSeconds > 0)
        {
            if (!started || !running)
                elapsedSeconds = 0;
            started = true;
			running = true;
		}
	}



    #endregion
}
