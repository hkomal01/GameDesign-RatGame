using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    public string new_scene;
    public gameHandler gameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Entity" && other.gameObject.name == "Player") {
            Debug.Log("enter new Scene");
            // string new_scene = "Level-1-3";
            SceneManager.LoadScene(new_scene);
            Destroy(gameObject);
        }
    }
}
