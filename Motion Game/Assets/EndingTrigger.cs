using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTrigger : MonoBehaviour
{
    public Collider player;

    Ending endingScript;

    public AudioSource music;

    void Start()
    {

        endingScript = GameObject.FindGameObjectWithTag("Trigger").GetComponent<Ending>();

    }
    public void OnTriggerEnter(Collider player)
    {

        Debug.Log("Triggered");
        endingScript.FadeRestart();
    }

}
