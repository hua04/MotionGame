using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public Animator animator;
    public AudioSource music;


    public void FadeRestart()
    {
        animator.SetTrigger("Win");
    }


    public void AudioOff()
    {
        music.Stop();
    }

}
