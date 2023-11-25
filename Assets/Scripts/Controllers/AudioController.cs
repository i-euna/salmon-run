using UnityEngine;

public class AudioController : Singleton
{
    [Tooltip("Background music Source")]
    [SerializeField]
    private AudioSource Music;

    [Tooltip("Ambient sound source")]
    [SerializeField]
    private AudioSource Ambient;

    [Tooltip("Stone sound source")]
    [SerializeField]
    private AudioSource Stone;

    [Tooltip("Bear sound source")]
    [SerializeField]
    private AudioSource Bear;

    [Tooltip("Human sound source")]
    [SerializeField]
    private AudioSource Human;

    [Tooltip("Event for obstacle hit")]
    [SerializeField]
    private GameEventWithArg OnObstacleHit;

    private void Start()
    {
        PlayBackgroundMusic();
        PlayAmbientSound();
        AddActionListenerForEvents();
    }

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

    public void PlayObstacleSound(GameObject _fish, string obstacle) {
        Stone.Play();
    }

    /// <summary>
    /// Play stone sound
    /// </summary>
    public void PlayStoneSound()
    {
        Stone.Play();
    }

    /// <summary>
    /// Play bear sound
    /// </summary>
    public void PlayBearSound()
    {
        Bear.Play();
    }

    /// <summary>
    /// Play human sound
    /// </summary>
    public void PlayHumanSound()
    {
        Human.Play();
    }
}
