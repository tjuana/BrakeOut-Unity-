using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EffectUtils 
{
    #region Fields

    static SpeedupEffectMonitor data;

    #endregion

    #region Properties

    public static bool ActiveSpeed
    {
        get { return data.ActiveSpeed; }
    }

    public static float LeftTime
    {
        get { return data.LeftTime; }
    }
    #endregion

    #region Methods

    public static void Initialize()
    {
        data = Camera.main.GetComponent<SpeedupEffectMonitor>();
    }

    #endregion
}
