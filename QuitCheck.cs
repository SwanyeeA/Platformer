using System.Collections;
using SSystem.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class QuitCheck: MonoBehaviour
{
    private void private void Awake()
    {
        if(FindObjectsOfType<QuitCheck>().Length > 1
        {
            Destroy(gameObject);
            
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }
}