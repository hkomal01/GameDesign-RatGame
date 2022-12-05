using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Object.DontDestroyOnLoad example.
//
// This script example manages the playing audio. The GameObject with the
// "music" tag is the BackgroundMusic GameObject. The AudioSource has the
// audio attached to the AudioClip.

public class DontDestroy : MonoBehaviour
{
    //public GameObject obj;
    void Awake()
    {
       DontDestroyOnLoad(this.gameObject);
    }

    void Update() {
        if (SceneManager.GetActiveScene().name == "Menu") {
            Destroy(this.gameObject);
        }
        if (SceneManager.GetActiveScene().name == "Level-1-1") {
            Destroy(this.gameObject);
        }
    }
    
}