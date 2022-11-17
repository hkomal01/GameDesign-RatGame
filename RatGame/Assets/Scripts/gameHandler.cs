using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameHandler : MonoBehaviour
{
    public GameObject pauseMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            Pause();
        }
    }

    public void Pause() {
        pauseMenuUI.SetActive(true);
    }

    public void quit() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
    }
}
