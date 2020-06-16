using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;



/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";
    
    // configuration data with default values
    static float paddleMoveUnitsPerSecond = 5.77f;

    //colums of block
    static int lineBlock = 3;
    //lives
    static int lives = 25;
    //add points
    static int pointsStandart = 100;
    static int pointsBonus = 200;
    static int pointsPickup = 500;

    //spawn/death balls timer
    static float spawnTimerMin = 5.77700f;
    static float spawnTimerMax = 10.77700f;

    static float deathTimer = 15.77700f;
    static float timerFreezyBall = 1.7700f;

    //player Freeeezyyy
    static float timerFreezy = 1.17700f;

    //ball speed
    static float ballImpulseForce = 50;
    //speed ball timer
    static float speedTimer = 1.77f;
    //speed factor
    static float speedFactor = 1.77f;
    //
    static int bounceAngleHalfRange = 60;

    static int pickupBlockProbabilities = 20;
    static int standartBlockProbabilities = 70;
    static int bonusBlockProbabilities = 20;

    #endregion

    #region Properties

    /// <summary>
    /// Spawn balls timer 
    /// </summary>
    public float BounceAngleHalfRange
    {
        get { return bounceAngleHalfRange; }
    }

    /// <summary>
    /// Spawn balls timer 
    /// </summary>
    public float SpawnTimerMin
    {
        get { return spawnTimerMin; }
    }

    /// <summary>
    /// Spawn balls timer 
    /// </summary>
    public float SpawnTimerMax
    {
        get { return spawnTimerMax; }
    }

    /// <summary>
    /// Spawn balls timer 
    /// </summary>
    public float SpeedTimer
    {
        get { return speedTimer; }
    }

    /// <summary>
    /// Death balls timer 
    /// </summary>
    public float DeathTimer
    {
        get { return deathTimer; }
    }

    /// <summary>
    /// Freezy player timer 
    /// </summary>
    public float TimerFreezy
    {
        get { return timerFreezy; }
    }

    /// <summary>
    /// Freezy ball timer 
    /// </summary>
    public float TimerFreezyBall
    {
        get { return timerFreezyBall; }
    }

    /// <summary>
    /// Sped of the ball
    /// </summary>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }
    }

    /// <summary>
    /// points standart block
    /// </summary>
    public int PointsStandart
    {
        get { return pointsStandart; }
    }

    /// <summary>
    /// number of strings block
    /// </summary>
    public int PointsBonus
    {
        get { return pointsBonus; }
    }

    /// <summary>
    /// number of strings block
    /// </summary>
    public int PointsPickup
    {
        get { return pointsPickup; }
    }
    /// <summary>
    /// number of strings block
    /// </summary>
    public int LineBlock
    {
        get { return lineBlock; }
    }

    /// <summary>
    /// lives
    /// </summary>
    public int Lives
    {
        get { return lives; }
    }

    /// <summary>
    /// Gets the block move units per second
    /// </summary>
    /// <value>block move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    //Probabilities of blocks
    public int StandartBlockProbabilities
    {
        get { return standartBlockProbabilities; }
    }

    public int BonusBlockProbabilities
    {
        get { return bonusBlockProbabilities; }
    }

    public int PickupBlockProbabilities
    {
        get { return pickupBlockProbabilities; }
    }

    //speed factor of the balls
    public float SpeedFactor
    {
        get { return speedFactor; }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        // read and save configuration data from file
        StreamReader read = null;
        string line;

        try
        {

            // create stream reader object
            read = File.OpenText(Path.Combine(
                Application.streamingAssetsPath, ConfigurationDataFileName));
            ///names
            line = read.ReadLine();
            ///values
            line = read.ReadLine();
            SetConfigurationDataFields(line);

        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        finally
        {
            if (read != null)
                read.Close();
            Debug.Log("man we did it");
        }

    }


    /// <summary>
    /// Sets the configuration data fields from the provided
    /// csv string
    /// </summary>
    /// <param name="csvValues">csv string of values</param>
    static void SetConfigurationDataFields(string csvValues)
    {
        string[] split;
        string[] sep = new string[] { ";" };
        split = csvValues.Split(sep, StringSplitOptions.None);
        // configuration data with csv file values
        paddleMoveUnitsPerSecond = float.Parse(split[0]);

        spawnTimerMin = float.Parse(split[1]);
        spawnTimerMax = float.Parse(split[2]);

        deathTimer = float.Parse(split[3]);
        timerFreezy = float.Parse(split[4]);

        lineBlock = int.Parse(split[5]);
        pointsStandart = int.Parse(split[6]);
        pointsBonus = int.Parse(split[7]);
        pointsPickup = int.Parse(split[8]);


        ballImpulseForce = float.Parse(split[9]);
        speedTimer = float.Parse(split[10]);
        lives = int.Parse(split[11]);

        bounceAngleHalfRange = int.Parse(split[12]);
        standartBlockProbabilities = int.Parse(split[13]);
        bonusBlockProbabilities = int.Parse(split[14]);
        pickupBlockProbabilities = int.Parse(split[15]);
        speedFactor = float.Parse(split[16]);
    }

    #endregion
}
