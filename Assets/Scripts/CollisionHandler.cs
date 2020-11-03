using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In seconds")][SerializeField] float levelLoadDelay = 1f;
    [SerializeField] GameObject deathFX;
    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke("reloadScene", levelLoadDelay);
    }

    private void StartDeathSequence()
    {
        SendMessage("flagDying");
    }
    private void reloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
