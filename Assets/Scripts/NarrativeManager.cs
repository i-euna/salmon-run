using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NarrativeManager : MonoBehaviour
{
  public TMP_Text signText;
  public Animator animator;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void ShowText(string text)
  {
    signText.text = text;
    animator.SetBool("Play", true);
  }

  public void Stop()
  {
    animator.SetBool("Play", false);
  }
}
