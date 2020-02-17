using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("music");

        Invoke("LoadFirstLevel", 2f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
}
