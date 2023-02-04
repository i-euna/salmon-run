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

    }

    public void PlayEffect(int Clip) {

        EffectSource.PlayOneShot(EffectClips[Clip]);
        //EffectSource.mute = true;
        //StartCoroutine(Mute(1));
        //StartCoroutine(Unmute(4));
    }

    private IEnumerator Mute(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            EffectSource.mute = true;
        }
    }

    private IEnumerator Unmute(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            EffectSource.mute = false;
        }
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
