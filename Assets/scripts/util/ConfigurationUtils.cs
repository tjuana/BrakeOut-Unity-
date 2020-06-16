using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    static ConfigurationData data;

    #region Properties
    /// <summary>
    /// 
    /// </summary>
    /// <value>td</value>
    public static float BounceAngleHalfRange
    {
        get { return data.BounceAngleHalfRange; }
    }

    /// <summary>
    /// Gets the teddy bear move units per second
    /// </summary>
    /// <value>teddy bear move units per second</value>
    public static float BallImpulseForce
    {
        get { return data.BallImpulseForce; }
    }

    /// <summary>
    /// Gets the teddy bear move units per second
    /// </summary>
    /// <value>teddy bear move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return data.PaddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the cooldown seconds for spawning balls
    /// </summary>
    /// <value>cooldown seconds</value>
    public static float SpeedTimer
    {
        get { return data.SpeedTimer; }
    }

    /// <summary>
    /// Gets the cooldown seconds for spawning balls
    /// </summary>
    /// <value>cooldown seconds</value>
    public static float SpawnTimerMin
    {
        get { return data.SpawnTimerMin; }
    }

    /// <summary>
    /// Gets the cooldown seconds for spawning balls
    /// </summary>
    /// <value>cooldown seconds</value>
    public static float SpawnTimerMax
    {
        get { return data.SpawnTimerMax; }
    }

    /// <summary>
    /// Gets the cooldown seconds for spawning balls
    /// </summary>
    /// <value>cooldown seconds</value>
    public static float DeathTimer
    {
        get { return data.DeathTimer; }
    }

    /// <summary>
    /// Gets the cooldown seconds for spawning balls
    /// </summary>
    /// <value>cooldown seconds</value>
    public static float TimerFreezy
    {
        get { return data.TimerFreezy; }
    }

    /// <summary>
    /// Gets the cooldown seconds for spawning balls
    /// </summary>
    /// <value>cooldown seconds</value>
    public static float TimerFreezyBall
    {
        get { return data.TimerFreezyBall; }
    }


    /// <summary>
    /// number of lines blocks
    /// </summary>
    /// <value>numbers of lines</value>
    public static int LineBlock
    {
        get { return data.LineBlock; }
    }

    /// <summary>
    /// score PointsStandart for one block
    /// </summary>
    /// <value>PointsStandart</value>
    public static int PointsStandart
    {
        get { return data.PointsStandart; }
    }

    /// <summary>
    /// score PointsBonus for one block
    /// </summary>
    /// <value>PointsStandart</value>
    public static int PointsBonus
    {
        get { return data.PointsBonus; }
    }

    /// <summary>
    /// score PointsPickup for one block
    /// </summary>
    /// <value>PointsStandart</value>
    public static int PointsPickup
    {
        get { return data.PointsPickup; }
    }

    /// <summary>
    /// Probabilites of blocks you have
    /// </summary>
    /// <value>Lives</value>
    public static int Lives
    {
        get { return data.Lives; }
    }

    public static int StandartBlockProbabilities
    {
        get { return data.StandartBlockProbabilities; }
    }

    public static int BonusBlockProbabilities
    {
        get { return data.BonusBlockProbabilities; }
    }

    public static int PickupBlockProbabilities
    {
        get { return data.PickupBlockProbabilities; }
    }

    public static float SpeedFactor
    {
        get { return data.SpeedFactor; }
    }
    #endregion

    #region Constructor
    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        data = new ConfigurationData();
    }
    #endregion
}
