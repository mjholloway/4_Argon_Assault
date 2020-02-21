using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObstacle : MonoBehaviour
{
    [SerializeField] GameObject deathFx;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 5;

    ScoreBoard scoreBoard;
    int hitInFrame;

    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
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
