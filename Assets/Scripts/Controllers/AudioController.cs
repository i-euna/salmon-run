using UnityEngine;

public class AudioController : Singleton
{
    [Header("Audio Sources")]
    [Tooltip("Background music Source")]
    [SerializeField]
    private AudioSource Music;

    [Tooltip("Ambient sound source")]
    [SerializeField]
    private AudioSource Ambient;

    [Tooltip("Obstacle sound source")]
    [SerializeField]
    private AudioSource ObstacleSource;

    [Tooltip("Obstacle sound clips")]
    [SerializeField]
    private AudioClip[] AudioClips;

    [Header("Events")]
    [Tooltip("Event for obstacle hit")]
    [SerializeField]
    private GameEventWithObjAndStr OnObstacleHit;

    private void Start()
    {
        PlayBackgroundMusic();
        PlayAmbientSound();
    }

    /// <summary>
    /// Play Background music
    /// </summary>
    private void PlayBackgroundMusic()
    {
        Music.loop = true;
        Music.Play();
    }

    /// <summary>
    /// Play ambient sound
    /// </summary>
    private void PlayAmbientSound()
    {
        Ambient.loop = true;
        Ambient.Play();
    }

    /// <summary>
    /// Play obstacle sounds
    /// </summary>
    /// <param name="_fish">fish game object</param>
    /// <param name="obstacle">obstacle type</param>
    public void PlayObstacleSound(int index) {
        ObstacleSource.volume = index == (int)ObstacleAudioClips.STONE ? 0.5f : 1;
        ObstacleSource.clip = AudioClips[index];
        ObstacleSource.Play();
    }
}

public enum ObstacleAudioClips { 
    STONE,
    FISHERMAN,
    BEAR
}