using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public GameObject MusicManager, AmbianceManager;
    [SerializeField]
    private AudioSource EffectSource;
    public AudioClip[] EffectClips;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }

        PlayBearEffect();
    }

    public void PlayBearEffect() {
        EffectSource.PlayOneShot(EffectClips[0]);
    }

    public void PlayHumanMadeWasteEffect()
    {
        EffectSource.PlayOneShot(EffectClips[1]);
    }

    public void PlayLogEffect()
    {
        EffectSource.PlayOneShot(EffectClips[2]);
    }

    public void PlaySeagull()
    {
        EffectSource.PlayOneShot(EffectClips[3]);
    }

    public void PlayStone()
    {
        EffectSource.PlayOneShot(EffectClips[4]);
    }

    public void PlayBackgroundMusic()
    {
        MusicManager.SetActive(true);
    }

    public void PlayAmbiance()
    {
        AmbianceManager.SetActive(true);
    }

}
