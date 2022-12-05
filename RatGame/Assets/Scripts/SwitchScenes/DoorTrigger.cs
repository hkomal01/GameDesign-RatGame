using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    public string new_scene;
    public float x_pos;
    public float y_pos;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
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
            player.transform.position = new Vector3(x_pos, y_pos, 0);
            Destroy(gameObject);
        }
    }
}
