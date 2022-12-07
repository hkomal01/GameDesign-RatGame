using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start() {
        Cursor.lockState = CursorLockMode.None;
        PlayerPrefs.SetFloat("Sensitivity", 1f);

        Update();
    }

    void Update() {
        Debug.Log("update");
    }

    public void PlayGame() {
        PlayerPrefs.SetFloat("Health", 4);
        
        SceneManager.LoadScene("Level-1-1");
    }

    public void quit() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
    }

    public void enterTutorial() {
        PlayerPrefs.SetFloat("Health", 4);
        SceneManager.LoadScene("Tutorial");
    }
}
