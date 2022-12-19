using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TutorialUI : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject[] stars;

    public GameObject player;

    public GameObject pauseMenuUI;
    public GameObject Darken;
    public GameObject tutorialUI;
    public TMP_Text text;

    //public GameHandler gameHandler;

    public float waitTime = 0.0f;
    public float tutorialIndex = 0;
    public bool taskFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        Resume();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            if(GameIsPaused && tutorialUI.activeSelf) {
                Resume();
                tutorialUI.SetActive(false);
            }
        }
            if(tutorialIndex == 0) {
                    waitTime = 3f;
                    Tutorial();
                    text.text = "welcome to tutorial!";
                    tutorialUI.SetActive(true);
                    tutorialIndex++;
                    waitTime = 0.01f;
            } else if(tutorialIndex == 1) {
                if(waitTime > 0) {
                    waitTime -= Time.deltaTime;
                } else {
                    Tutorial();
                    text.text = "use WASD to move, left mouse to shoot, esc to call pause menu";
                    tutorialUI.SetActive(true);
                    tutorialIndex++;
                    waitTime = .01f;
                }
            } else if(tutorialIndex == 2) {
                if(waitTime > 0) {
                    waitTime -= Time.deltaTime;
                } else {
                    Tutorial();
                    text.text = "enemy bullet and enemy touch will cause damage";
                    tutorialUI.SetActive(true);
                    tutorialIndex++;
                    waitTime = .01f;
                }
            } else if(tutorialIndex == 3) {
                if(waitTime > 0) {
                    waitTime -= Time.deltaTime;
                } else {
                    Tutorial();
                    text.text = "door is located on side of the map and will open when all the enemies are killed, the crate are destroyable!";
                    tutorialUI.SetActive(true);
                    tutorialIndex++;
                    waitTime = .01f;
                }
            } else if(tutorialIndex == 4) {
                if(waitTime > 0) {
                    waitTime -= Time.deltaTime;
                } else {
                    Tutorial();
                    text.text = "health is located on the upper left corner, silver heart in game is the health portion";
                    tutorialUI.SetActive(true);
                    tutorialIndex++;
                    waitTime = .01f;
                }
            } else if(tutorialIndex == 5) {
                if(waitTime > 0) {
                    waitTime -= Time.deltaTime;
                } else {
                    Tutorial();
                    text.text = "press E to pick up any weapon on ground!";
                    tutorialUI.SetActive(true);
                    tutorialIndex++;
                    waitTime = .01f;
                }
            }
        
    }



    public void Tutorial()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume() {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        player.SetActive(true);
    }

    IEnumerator waiter(int j)
    {
        for (int i = 0; i <= j; i++)
        {
            stars[i].SetActive(true);
            stars[i].GetComponent<Animator>().Play("Star");
            yield return new WaitForSeconds(1);
        }
    }
}
