using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // okay as long as this is the only script that loads scenes

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float LoadLevelDelay = 1f;
    [SerializeField] GameObject deathFx;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFx.SetActive(true);
        Invoke("ReloadLevel", LoadLevelDelay);
    }

    private void StartDeathSequence()
    {
        gameObject.SendMessage("DetermineDeath");
    }

    private void ReloadLevel() // string referenced
    {
        SceneManager.LoadScene(1);
    }
}
