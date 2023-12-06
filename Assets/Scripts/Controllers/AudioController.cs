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

    [Tooltip("Stone sound source")]
    [SerializeField]
    private AudioSource Stone;

    [Tooltip("Bear sound source")]
    [SerializeField]
    private AudioSource Bear;

    [Tooltip("Human sound source")]
    [SerializeField]
    private AudioSource Human;

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
        AddActionListenerForEvents();
    }

    /// <summary>
    /// Dynamic callback for event
    /// </summary>
    private void AddActionListenerForEvents() {
        OnObstacleHit.Event.AddListener(PlayObstacleSound);
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
    public void PlayObstacleSound(GameObject _fish, string obstacle) {
        int index = 0;
        switch (obstacle)
        {
            case ObstacleNames.STONE:
                index = (int)ObstacleAudioClips.STONE;
                break;
            case ObstacleNames.FISHERMAN:
                index = (int)ObstacleAudioClips.FISHERMAN;
                break;
            case ObstacleNames.BEAR:
                index = (int)ObstacleAudioClips.BEAR;
                break;
            default:
                break;
        }
        ObstacleSource.clip = AudioClips[index];
        ObstacleSource.Play();
    }
}

public enum ObstacleAudioClips { 
    STONE,
    FISHERMAN,
    BEAR
}