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

    public float waitTime = .5f;
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
                    waitTime = 3f;
            } else if(tutorialIndex == 1) {
                if(waitTime > 0) {
                    waitTime -= Time.deltaTime;
                } else {
                    Tutorial();
                    text.text = "use WASD to move";
                    tutorialUI.SetActive(true);
                    tutorialIndex++;
                    waitTime = 3f;
                }
            } else if(tutorialIndex == 2) {
                if(waitTime > 0) {
                    waitTime -= Time.deltaTime;
                } else {
                    Tutorial();
                    text.text = "enemy Bullet and enemy touch will cause damage";
                    tutorialUI.SetActive(true);
                    tutorialIndex++;
                    waitTime = 3f;
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
