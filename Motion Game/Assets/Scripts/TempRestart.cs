using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempRestart : MonoBehaviour
{
 
    private void OnTriggerEnter(Collider player)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
