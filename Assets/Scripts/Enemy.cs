﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFx;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 10;

    ScoreBoard scoreBoard;
    int hitInFrame;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (Time.frameCount == hitInFrame) { return; }

        scoreBoard.ScoreHit(scorePerHit);
        GameObject Fx = Instantiate(deathFx, transform.position, Quaternion.identity);
        Fx.transform.parent = parent;
        Destroy(gameObject);
        hitInFrame = Time.frameCount;
    }
}
