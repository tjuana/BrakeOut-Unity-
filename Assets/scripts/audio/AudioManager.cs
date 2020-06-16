using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The audio manager
/// </summary>
public static class AudioManager
{
    static bool initialazed = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    public static bool Initialized
    {
        get { return initialazed; }
    }

    /// <summary>
    /// Initializes the audio manager
    /// </summary>
    /// <param name="source">audio source</param>
    public static void Initialize(AudioSource source)
    {
        initialazed = true;
        audioSource = source;
        audioClips.Add(AudioClipName.BallHit, 
            Resources.Load<AudioClip>("hit"));
        audioClips.Add(AudioClipName.PlayerDeath,
            Resources.Load<AudioClip>("die"));
        audioClips.Add(AudioClipName.BallSpawn,
            Resources.Load<AudioClip>("spawn"));
        audioClips.Add(AudioClipName.SpeedBallActive,
            Resources.Load<AudioClip>("speedBall0"));
        audioClips.Add(AudioClipName.FreezyActive,
            Resources.Load<AudioClip>("freezy0"));
        audioClips.Add(AudioClipName.SpeedBallDisable,
            Resources.Load<AudioClip>("speedBall1"));
        audioClips.Add(AudioClipName.FreezyDisable,
             Resources.Load<AudioClip>("freezy1"));
        audioClips.Add(AudioClipName.GameOver,
            Resources.Load<AudioClip>("gameOver"));
        audioClips.Add(AudioClipName.Click,
            Resources.Load<AudioClip>("click"));
    }

    /// <summary>
    /// Plays the audio clip with the given name
    /// </summary>
    /// <param name="name">name of the audio clip to play</param>
    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name], 0.77f);
    }

}
