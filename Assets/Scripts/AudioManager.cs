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
    else
    {
      Destroy(gameObject);
    }
    PlayBackgroundMusic();

  }

  public void PlayEffect(int Clip)
  {
    EffectSource.PlayOneShot(EffectClips[Clip]);
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
