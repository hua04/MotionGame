using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartTrigger : MonoBehaviour
{
    public Collider player;
   
    Restart restartScript;

    void Start()
    {

        restartScript = GameObject.FindGameObjectWithTag("Trigger").GetComponent<Restart>();

    }
    public void OnTriggerEnter(Collider player)
    {
       
        Debug.Log("Triggered");
        restartScript.FadeRestart();
    }
}
