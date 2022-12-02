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
}
