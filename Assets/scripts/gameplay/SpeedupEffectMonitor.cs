using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedupEffectMonitor : MonoBehaviour
{
    #region Fields



    Timer speddyTimer;
    float velocity;
    bool activeSpeed = false;
    float leftTime = 0;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        speddyTimer = gameObject.AddComponent<Timer>();
        EventManager.AddSpeddyListener(SpeddyWay);
    }
    #region Properties

    public bool ActiveSpeed
    {
        get { return activeSpeed; }
    }

    public float LeftTime
    {
        get { return leftTime; }
    }
    #endregion
    private void Update()
    {
        if (activeSpeed)
            leftTime = speddyTimer.LeftTime;
    }

    void SpeddyWay(float duration, float speedFactor)
    {
        speddyTimer.AddTimerFinishedEventListener(HandleHomingTimerFinishedEvent);
        speddyTimer.Duration = duration;
        speddyTimer.Run();
        activeSpeed = true;
    }

    void HandleHomingTimerFinishedEvent()
    {
        activeSpeed = false;
    }
}
