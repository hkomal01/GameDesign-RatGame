using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void start() {
        Cursor.lockState = CursorLockMode.None;
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
